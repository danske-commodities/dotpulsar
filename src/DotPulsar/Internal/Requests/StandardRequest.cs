﻿/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace DotPulsar.Internal.Requests
{
    using DotPulsar.Internal.Abstractions;
    using System;
    using System.Diagnostics.CodeAnalysis;

    public struct StandardRequest : IRequest
    {
        public ulong RequestId { get; }

        public StandardRequest(ulong requestId)
            => RequestId = requestId;

#if NETSTANDARD2_0
        public bool Equals(IRequest other)
#else
        public bool Equals([AllowNull] IRequest other)
#endif
        {
            if (other is StandardRequest request)
                return RequestId.Equals(request.RequestId);

            return false;
        }

        public override int GetHashCode()
            => HashCode.Combine(RequestId);
    }
}
