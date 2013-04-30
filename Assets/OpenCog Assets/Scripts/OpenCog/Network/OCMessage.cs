
/// Unity3D OpenCog World Embodiment Program
/// Copyright (C) 2013  Novamente			
///
/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Affero General Public License as
/// published by the Free Software Foundation, either version 3 of the
/// License, or (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU Affero General Public License for more details.
///
/// You should have received a copy of the GNU Affero General Public License
/// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#region Usings, Namespaces, and Pragmas

using System.Collections;
using OpenCog.Attributes;
using OpenCog.Extensions;
using IConvertible = System.IConvertible;
using ImplicitFields = ProtoBuf.ImplicitFields;
using ProtoContract = ProtoBuf.ProtoContractAttribute;
using Serializable = System.SerializableAttribute;

//The private field is assigned but its value is never used
#pragma warning disable 0414

#endregion

namespace OpenCog.Network
{

/// <summary>
/// The OpenCog Message.  Subclasses that extend fromit can obtain instances
/// via factory method.  @TODO: is this supposed to be a class cluster?  
/// Something fishy about all this...
/// </summary>
#region Class Attributes

[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
[OCExposePropertyFields]
[Serializable]
	
#endregion
public abstract class OCMessage : IConvertible 
{

	//---------------------------------------------------------------------------

	#region Private Member Data

	//---------------------------------------------------------------------------
	
	/// <summary>
	/// The ID of source OCNetworkElement.
	/// </summary>
	private string m_SourceID;
		
	/// <summary>
	/// The ID of the target OCNetworkElement.
	/// </summary>
	private string m_TargetID;
		
	/// <summary>
	/// The type of the message.
	/// </summary>
	private MessageType m_Type;
		
		
			
	//---------------------------------------------------------------------------

	#endregion

	//---------------------------------------------------------------------------

	#region Accessors and Mutators

	//---------------------------------------------------------------------------
		
	public string SourceID 
	{
		get { return this.m_SourceID;}
		set { m_SourceID = value;}
	}

	public string TargetID 
	{
		get { return this.m_TargetID;}
		set { m_TargetID = value;}
	}

	public MessageType Type 
	{
		get { return this.m_Type;}
		set { m_Type = value;}
	}
			
	//---------------------------------------------------------------------------

	#endregion

	//---------------------------------------------------------------------------

	#region Public Member Functions

	//---------------------------------------------------------------------------
		
	/// <summary>
	/// Creates the message.
	/// </summary>
	/// <returns>
	/// The message.
	/// </returns>
	/// <param name='sourceID'>
	/// Source I.
	/// </param>
	/// <param name='targetID'>
	/// Target I.
	/// </param>
	/// <param name='type'>
	/// Type.
	/// </param>
	/// <param name='message'>
	/// Message.
	/// </param>
	public static OCMessage 
	CreateMessage
	(	string sourceID
	, string targetID
	, MessageType type
	, string message
	)
	{
		switch(type)
		{
			case MessageType.STRING:
				return new OCStringMessage(sourceID, targetID, message);
			case MessageType.FEEDBACK:
				return new OCFeedbackMessage(sourceID, targetID, message);				
			case MessageType.RAW:
				return new OCRawMessage(sourceID, targetID, message);
			default:
				return null;
		}
	}
		
	public abstract string ToString();
	
	public abstract void FromString(string message);

	#region IConvertible implementation
	public System.TypeCode GetTypeCode ()
	{
		throw new System.NotImplementedException ();
	}

	public bool ToBoolean (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public char ToChar (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public sbyte ToSByte (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public byte ToByte (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public short ToInt16 (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public ushort ToUInt16 (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public int ToInt32 (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public uint ToUInt32 (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public long ToInt64 (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public ulong ToUInt64 (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public float ToSingle (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public double ToDouble (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public decimal ToDecimal (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public System.DateTime ToDateTime (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public string ToString (System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}

	public object ToType (System.Type conversionType, System.IFormatProvider provider)
	{
		throw new System.NotImplementedException ();
	}
		
	#endregion
	//---------------------------------------------------------------------------

	#endregion

	//---------------------------------------------------------------------------

	#region Private Member Functions

	//---------------------------------------------------------------------------
	
	
			
	//---------------------------------------------------------------------------

	#endregion

	//---------------------------------------------------------------------------

	#region Other Members

	//---------------------------------------------------------------------------		
		
	public OCMessage (string sourceID, string targetID, MessageType type)
	{
		m_SourceID = sourceID;
		m_TargetID = targetID;
		m_Type = type;
	}
		
	/// <summary>
	/// Message types definition.
	/// </summary>
	public enum MessageType : int
	{
		NONE = 0
	, STRING = 1
	, LEARN = 2
	, REWARD = 3
	, SCHEMA = 4
	, LS_CMD = 5
	, ROUTER = 6
	, CANDIDATE_SCHEMA = 7
	, TICK = 8
	, FEEDBACK = 9
	, TRY = 10
	, STOP_LEARNING = 11
	/// <summary>
	/// A custom message type for test purposes, to be removed.
	/// </summary>
	, RAW = 12
	}

	//---------------------------------------------------------------------------

	#endregion

	//---------------------------------------------------------------------------

}// class OCMessage

}// namespace OpenCog.Network




