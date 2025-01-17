﻿using Common.Networking.IO;
using Common.Networking.Message;

namespace GameServer.Server.Packets
{
    public class WPacketLogin : IWritable
    {
        public LoginResponseOpcode LoginOpcode { private get; set; }
        public byte VersionMajor { private get; set; }
        public byte VersionMinor { private get; set; }
        public byte VersionPatch { private get; set; }
        public uint Gold { get; set; }
        public uint StructureHuts { get; set; }

        public void Write(PacketWriter writer)
        {
            writer.Write((byte)LoginOpcode);

            switch (LoginOpcode) 
            {
                case LoginResponseOpcode.VersionMismatch:
                    writer.Write(VersionMajor);
                    writer.Write(VersionMinor);
                    writer.Write(VersionPatch);
                    break;
                case LoginResponseOpcode.LoginSuccess:
                    writer.Write(Gold);
                    writer.Write(StructureHuts);
                    break;
            }
        }
    }
}
