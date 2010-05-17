using System;

namespace EDM.FoundationClasses.FoundationType
{
    public enum WhiteSpaceEnum
    {
        /// <summary>
        /// preserve - No normalization is done, the value is not changed (this is the behavior required by [XML 1.0 (Second Edition)] for element content)
        /// replace - All occurrences of #x9 (tab), #xA (line feed) and #xD (carriage return) are replaced with #x20 (space)
        /// collapse - After the processing implied by replace, contiguous sequences of #x20's are collapsed to a single #x20, and leading and trailing #x20's are removed.
        /// </summary>
         Preserve = 0x0
        ,Replace  = 0x2
        ,Collapse = 0x4

    }
}
