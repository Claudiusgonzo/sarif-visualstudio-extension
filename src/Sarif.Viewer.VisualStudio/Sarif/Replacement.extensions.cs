﻿// Copyright (c) Microsoft. All rights reserved. 
// Licensed under the MIT license. See LICENSE file in the project root for full license information. 

using System;
using Microsoft.CodeAnalysis.Sarif;
using Microsoft.Sarif.Viewer.Models;

namespace Microsoft.Sarif.Viewer.Sarif
{
    static class ReplacementExtensions
    {
        public static ReplacementModel ToReplacementModel(this Replacement replacement)
        {
            if (replacement == null)
            {
                return null;
            }

            ReplacementModel model = new ReplacementModel();

            if (!string.IsNullOrWhiteSpace(replacement.InsertedContent?.Text))
            {
                model.DeletedLength = replacement.DeletedRegion.CharLength;
                model.Offset = replacement.DeletedRegion.CharOffset;
                model.InsertedString = replacement.InsertedContent.Text;
            }
            else if (replacement.InsertedContent?.Binary != null)
            {
                model.DeletedLength = replacement.DeletedRegion.ByteLength;
                model.Offset = replacement.DeletedRegion.ByteOffset;
                model.InsertedBytes = Convert.FromBase64String(replacement.InsertedContent.Binary);
            }

            return model;
        }
    }
}
