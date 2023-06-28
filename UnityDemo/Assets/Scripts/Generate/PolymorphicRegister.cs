﻿using MessagePack;
using MessagePack.Resolvers;
using PolymorphicMessagePack;
using Protocol;
using Resolvers;

namespace Protocol
{
    public partial class PolymorphicRegister
    {

        static bool serializerRegistered = false;
        private static void Init()
        {
            if (!serializerRegistered)
            {
                PolymorphicResolver.AddInnerResolver(ConfigDataResolver.Instance);
                PolymorphicResolver.AddInnerResolver(MessagePack.Resolvers.GeneratedResolver.Instance);
                PolymorphicTypeMapper.Register<Message>();
                PolymorphicResolver.Instance.Init();
                serializerRegistered = true;
            }
        }

        public static void Load() { Init(); }
    }
}
