﻿using Deadlocked.Server.Stream;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Deadlocked.Server.Messages.MGCL
{
    [MediusApp(MediusAppPacketIds.MediusServerEndGameRequest)]
    public class MediusServerEndGameRequest : BaseMGCLMessage
    {

        public override MediusAppPacketIds Id => MediusAppPacketIds.MediusServerEndGameRequest;

        public int WorldID;
        public char BrutalFlag;

        public override void Deserialize(BinaryReader reader)
        {
            // 
            base.Deserialize(reader);

            // 
            reader.ReadBytes(3);
            WorldID = reader.ReadInt32();
            BrutalFlag = reader.ReadChar();
        }

        public override void Serialize(BinaryWriter writer)
        {
            // 
            base.Serialize(writer);

            // 
            writer.Write(new byte[3]);
            writer.Write(WorldID);
            writer.Write(BrutalFlag);
        }


        public override string ToString()
        {
            return base.ToString() + " " +
             $"WorldID:{WorldID}" + " " +
$"BrutalFlag:{BrutalFlag}";
        }
    }
}