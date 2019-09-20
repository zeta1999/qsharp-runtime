﻿using System;
using System.Runtime.InteropServices;
using Microsoft.Quantum.Simulation.Core;

namespace Microsoft.Quantum.Simulation.Circuitizer
{
    public partial class CircuitizerSimulator
    {
        public class CircuitizerSimT : Quantum.Intrinsic.T
        {
            private CircuitizerSimulator Simulator { get; }


            public CircuitizerSimT(CircuitizerSimulator m) : base(m)
            {
                this.Simulator = m;
            }

            public override Func<Qubit, QVoid> Body => (q1) =>
            {

                Simulator.Circuitizer.T(q1);
                return QVoid.Instance;
            };

            public override Func<(IQArray<Qubit>, Qubit), QVoid> ControlledBody => (_args) =>
            {

                (IQArray<Qubit> ctrls, Qubit q1) = _args;

                Simulator.Circuitizer.ControlledT(ctrls, q1);

                return QVoid.Instance;
            };

            public override Func<Qubit, QVoid> AdjointBody => (q1) =>
            {

                Simulator.Circuitizer.TAdj(q1);
                return QVoid.Instance;
            };

            public override Func<(IQArray<Qubit>, Qubit), QVoid> ControlledAdjointBody => (_args) =>
            {

                (IQArray<Qubit> ctrls, Qubit q1) = _args;
                Simulator.Circuitizer.ControlledTAdj(ctrls, q1);
                return QVoid.Instance;
            };
        }
    }
}