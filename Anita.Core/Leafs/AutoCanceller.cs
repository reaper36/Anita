﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using SachsenCoder.Anita.Contracts.Data;

namespace SachsenCoder.Anita.Core.Leafs
{
    public sealed class AutoCanceller<T>
    {
        public void Input(CancelSource<T> cancelSource)
        {
            if (_lastCancelSource == null) {
                _lastCancelSource = cancelSource.CancelTokenSource;
                return; 
            }

            _lastCancelSource.Cancel();
            _lastCancelSource = cancelSource.CancelTokenSource;
        }

        private CancellationTokenSource _lastCancelSource;
    }
}