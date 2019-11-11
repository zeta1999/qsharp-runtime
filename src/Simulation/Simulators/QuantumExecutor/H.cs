﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Quantum.Simulation.Core;

namespace Microsoft.Quantum.Simulation.QuantumExecutor
{
    public partial class QuantumExecutorSimulator
    {
        public class QuantumExecutorSimH : Quantum.Intrinsic.H
        {
            private QuantumExecutorSimulator Simulator { get; }


            public QuantumExecutorSimH(QuantumExecutorSimulator m) : base(m)
            {
                this.Simulator = m;
            }

            public override Func<Qubit, QVoid> Body => (q1) =>
            {

                Simulator.QuantumExecutor.H(q1);
                return QVoid.Instance;
            };


            public override Func<(IQArray<Qubit>, Qubit), QVoid> ControlledBody => (args) =>
            {

                var (ctrls, q1) = args;
                Simulator.QuantumExecutor.ControlledH(ctrls,q1);
                return QVoid.Instance;
            };
        }
    }
}
