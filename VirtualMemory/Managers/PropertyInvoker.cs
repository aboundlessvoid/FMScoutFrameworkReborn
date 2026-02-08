using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FMScoutFramework.Core.Entities;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Managers
{
	internal static class PropertyInvoker
	{
		public static T Get<T>(int offset, ArraySegment<byte> baseObject, Int64 memoryAddress, DatabaseModeEnum databaseMode)
		{
			if (databaseMode == DatabaseModeEnum.Cached)
				return (T)ProcessManager.ReadFromBuffer (baseObject.Array, baseObject.Offset + offset, typeof(T));
			else { // realtime
                Int64 offsetToFind = memoryAddress + offset;

				if (typeof(Int16) == typeof(T))
					return (T)(object)ProcessManager.ReadInt16 (offsetToFind);
				else if (typeof(Byte) == typeof(T))
					return (T)(object)ProcessManager.ReadByte (offsetToFind);
				else if (typeof(DateTime) == typeof(T))
					return (T)(object)ProcessManager.ReadDateTime (offsetToFind);
				else if (typeof(Int32) == typeof(T))
					return (T)(object)ProcessManager.ReadInt32 (offsetToFind);
				else if (typeof(SByte) == typeof(T))
					return (T)(object)ProcessManager.ReadSByte (offsetToFind);
				else if (typeof(float) == typeof(T))
					return (T)(object)ProcessManager.ReadFloat (offsetToFind);
				else if (typeof(UInt32) == typeof(T))
					return (T)(object)ProcessManager.ReadUInt32 (offsetToFind);
				else if (typeof(ushort) == typeof(T))
					return (T)(object)ProcessManager.ReadUInt16 (offsetToFind);
				else
					return default(T);
			}
		}

        public static void Set<T>(int offset, ArraySegment<byte> baseObject, Int64 memoryAddress, DatabaseModeEnum databaseMode, T value)
        {
            if (databaseMode == DatabaseModeEnum.Cached)
            {
                throw new NotImplementedException();
            }
            else
            {
                Int64 offsetToFind = memoryAddress + offset;

                if (typeof(Int16) == typeof(T))
                    ProcessManager.WriteInt16((short)(object)value, offsetToFind);
                else if (typeof(Byte) == typeof(T))
                    ProcessManager.WriteByte((byte)(object)value, offsetToFind);
                else if (typeof(DateTime) == typeof(T))
                    ProcessManager.WriteDateTime((DateTime)(object)value, offsetToFind);
                else if (typeof(Int32) == typeof(T))
                    ProcessManager.WriteInt32((int)(object)value, offsetToFind);
                else if (typeof(SByte) == typeof(T))
                    ProcessManager.WriteSByte((sbyte)(object)value, offsetToFind);
                else if (typeof(float) == typeof(T))
                    ProcessManager.WriteFloat((float)(object)value, offsetToFind);
                else if (typeof(UInt32) == typeof(T))
                    ProcessManager.WriteInt32((int)(object)value, offsetToFind);
                else if (typeof(ushort) == typeof(T))
                    ProcessManager.WriteInt16((ushort)(object)value, offsetToFind);
            }
        }


        public static string GetString(int offset, int additionalStringOffset, ArraySegment<byte> baseObject, Int64 memoryAddress, DatabaseModeEnum databaseMode)
		{
			if (databaseMode == DatabaseModeEnum.Cached)
				return ProcessManager.ReadString(baseObject, offset, additionalStringOffset);
			else // realtime
				return ProcessManager.ReadString(memoryAddress + offset, additionalStringOffset);
		}

		public static string GetHexColorValue(int offset, ArraySegment<byte> baseObject, Int64 memoryAddress, DatabaseModeEnum databaseMode)
		{
			UInt32 rgba = Get<UInt32>(offset, baseObject, memoryAddress, databaseMode);
            return rgba.ToString("X");
        }

        private static Dictionary<Type, Func<Int64, IVersion, object>> pointerDelegateDictionary = new Dictionary<Type, Func<Int64, IVersion, object>>();
		public static T GetPointer<T>(int offset, ArraySegment<byte> baseObject, Int64 memoryAddress, DatabaseModeEnum databaseMode, IVersion version)
			where T: class
		{
			if (databaseMode == DatabaseModeEnum.Cached) {
                Int64 memAddress = ProcessManager.ReadInt64 (baseObject.Array, offset + baseObject.Offset);
				var objectStore = ((Dictionary<Int64, T>)ObjectManagerWrapper.ObjectManagers [databaseMode].ObjectStore [typeof(T)]);
				if (objectStore.ContainsKey (memAddress))
					return objectStore [memAddress] as T;
				else
					return default(T);
			} else {
                Int64 memAddress = memoryAddress + offset;

				/*
				if (typeof(T) == typeof(Contract))
					memAddress = ProcessManager.ReadInt64 (memAddress); */

				if (!pointerDelegateDictionary.ContainsKey (typeof(T))) {
					System.Reflection.ConstructorInfo ci =
						typeof(T).GetConstructor (new[] { typeof(Int64), typeof(IVersion) });

					ParameterExpression memAddressParam = Expression.Parameter (typeof(Int64), "memAdd");
					ParameterExpression versionParam = Expression.Parameter (typeof(IVersion), "version");

					LambdaExpression lambda = Expression.Lambda (
						Expression.Convert (Expression.New (ci, memAddressParam, versionParam), typeof(object))
						, memAddressParam, versionParam);

					lock (pointerDelegateLock) {
						if (!pointerDelegateDictionary.ContainsKey (typeof(T))) {
							pointerDelegateDictionary.Add (typeof(T),
								(Func<Int64, IVersion, object>)lambda.Compile ());
						}
					}
				}
				return (T)pointerDelegateDictionary [typeof(T)].Invoke (ProcessManager.ReadInt64 (memAddress), version);
			}
		}

		private static object pointerDelegateLock = new object();
	}
}

