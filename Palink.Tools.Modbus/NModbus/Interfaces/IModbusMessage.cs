﻿namespace Palink.Tools.NModbus.Interfaces;

public interface IModbusMessage
{
    /// <summary>
    ///     The function code tells the server what kind of action to perform.
    /// </summary>
    byte FunctionCode { get; set; }

    /// <summary>
    ///     Address of the slave (server).
    /// </summary>
    byte SlaveAddress { get; set; }

    /// <summary>
    ///     Composition of the slave address and protocol data unit.
    /// </summary>
    byte[] MessageFrame { get; }

    /// <summary>
    ///     Composition of the function code and message data.
    /// </summary>
    byte[] ProtocolDataUnit { get; }

    /// <summary>
    ///     A unique identifier assigned to a message when using the IP protocol.
    /// </summary>
    ushort TransactionId { get; set; }

    /// <summary>
    ///     Initializes a modbus message from the specified message frame.
    /// </summary>
    /// <param name="frame">Bytes of Modbus frame.</param>
    void Initialize(byte[] frame);
}