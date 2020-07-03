﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Iot.Device.StUsb4500.Objects
{
    /// <summary>
    /// Base class for all the different power delivery objects (=PDO).
    /// </summary>
    public abstract class PowerDeliveryObject : ObjectBase
    {
        /// <summary>Gets the power of this PDO.</summary>
        public abstract double Power { get; }

        /// <summary>Initializes a new instance of the <see cref="PowerDeliveryObject"/> class.</summary>
        /// <param name="value">The value.</param>
        protected PowerDeliveryObject(uint value) => Value = value;

        /// <summary>Creates a new PDO from the given value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>A PDO of the type defined by the value.</returns>
        public static PowerDeliveryObject CreateFromValue(uint value)
        {
            uint pdoType = value >> 30;
            switch (pdoType)
            {
                case 0:
                    return new FixedSupplyObject(value);
                case 1:
                    return new VariableSupplyObject(value);
                case 2:
                    return new BatteryObject(value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }
    }
}
