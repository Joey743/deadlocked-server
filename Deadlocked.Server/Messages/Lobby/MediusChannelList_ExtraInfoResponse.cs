﻿using Deadlocked.Server.Stream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Deadlocked.Server.Messages.Lobby
{
    [MediusApp(MediusAppPacketIds.ChannelList_ExtraInfoResponse)]
    public class MediusChannelList_ExtraInfoResponse : BaseLobbyMessage
    {

        public override MediusAppPacketIds Id => MediusAppPacketIds.ChannelList_ExtraInfoResponse;

        public MediusCallbackStatus StatusCode;
        public int MediusWorldID;
        public ushort PlayerCount;
        public ushort MaxPlayers;
        public ushort GameWorldCount;
        public MediusWorldSecurityLevelType SecurityLevel;
        public uint GenericField1;
        public uint GenericField2;
        public uint GenericField3;
        public uint GenericField4;
        public MediusWorldGenericFieldLevelType GenericFieldLevel;
        public string LobbyName; // LOBBYNAME_MAXLEN
        public bool EndOfList;

        public override void Deserialize(BinaryReader reader)
        {
            // 
            base.Deserialize(reader);

            // 
            reader.ReadBytes(3);
            StatusCode = reader.Read<MediusCallbackStatus>();
            MediusWorldID = reader.ReadInt32();
            PlayerCount = reader.ReadUInt16();
            MaxPlayers = reader.ReadUInt16();
            GameWorldCount = reader.ReadUInt16();
            reader.ReadBytes(2);
            SecurityLevel = reader.Read<MediusWorldSecurityLevelType>();
            GenericField1 = reader.ReadUInt32();
            GenericField2 = reader.ReadUInt32();
            GenericField3 = reader.ReadUInt32();
            GenericField4 = reader.ReadUInt32();
            GenericFieldLevel = reader.Read<MediusWorldGenericFieldLevelType>();
            LobbyName = reader.ReadString(MediusConstants.LOBBYNAME_MAXLEN);
            EndOfList = reader.ReadBoolean();
            reader.ReadBytes(3);
        }

        public override void Serialize(BinaryWriter writer)
        {
            // 
            base.Serialize(writer);

            // 
            writer.Write(new byte[3]);
            writer.Write(StatusCode);
            writer.Write(MediusWorldID);
            writer.Write(PlayerCount);
            writer.Write(MaxPlayers);
            writer.Write(GameWorldCount);
            writer.Write(new byte[2]);
            writer.Write(SecurityLevel);
            writer.Write(GenericField1);
            writer.Write(GenericField2);
            writer.Write(GenericField3);
            writer.Write(GenericField4);
            writer.Write(GenericFieldLevel);
            writer.Write(LobbyName, MediusConstants.LOBBYNAME_MAXLEN);
            writer.Write(EndOfList);
            writer.Write(new byte[3]);
        }


        public override string ToString()
        {
            return base.ToString() + " " +
             $"StatusCode:{StatusCode}" + " " +
$"MediusWorldID:{MediusWorldID}" + " " +
$"PlayerCount:{PlayerCount}" + " " +
$"MaxPlayers:{MaxPlayers}" + " " +
$"GameWorldCount:{GameWorldCount}" + " " +
$"SecurityLevel:{SecurityLevel}" + " " +
$"GenericField1:{GenericField1}" + " " +
$"GenericField2:{GenericField2}" + " " +
$"GenericField3:{GenericField3}" + " " +
$"GenericField4:{GenericField4}" + " " +
$"GenericFieldLevel:{GenericFieldLevel}" + " " +
$"LobbyName:{LobbyName}" + " " +
$"EndOfList:{EndOfList}";
        }
    }
}