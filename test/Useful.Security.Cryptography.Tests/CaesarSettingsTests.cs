// Copyright (c) Andrew Hawkins. All rights reserved.

using Xunit;

namespace Useful.Security.Cryptography.Tests
{
    public class CaesarSettingsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(25)]
        public void Construct(int rightShift)
        {
            ICaesarSettings settings = new CaesarSettings() { RightShift = rightShift };

            Assert.Equal(rightShift, settings.RightShift);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(26)]
        public void ConstructOutOfRange(int rightShift)
            => Assert.Throws<ArgumentOutOfRangeException>(
                nameof(CaesarSettings.RightShift),
                () => new CaesarSettings()
                {
                    RightShift = rightShift,
                });

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(25)]
        public void SetRightShift(int rightShift)
        {
            ICaesarSettings settings = new CaesarSettings
            {
                RightShift = rightShift,
            };

            Assert.Equal(rightShift, settings.RightShift);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(26)]
        public void SetRightShiftOutOfRange(int rightShift)
        {
            ICaesarSettings settings = new CaesarSettings();
            Assert.Throws<ArgumentOutOfRangeException>(nameof(CaesarSettings.RightShift), () => settings.RightShift = rightShift);
        }
    }
}
