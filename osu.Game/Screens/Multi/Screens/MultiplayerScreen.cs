﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using osu.Game.Graphics.Containers;

namespace osu.Game.Screens.Multi.Screens
{
    public abstract class MultiplayerScreen : OsuScreen
    {
        protected virtual Container<Drawable> TransitionContent => Content;

        /// <summary>
        /// The type to display in the title of the <see cref="Header"/>.
        /// </summary>
        public virtual string Type => Title;

        protected override void OnEntering(Screen last)
        {
            base.OnEntering(last);

            Content.FadeInFromZero(WaveContainer.APPEAR_DURATION, Easing.OutQuint);
            TransitionContent.FadeInFromZero(WaveContainer.APPEAR_DURATION, Easing.OutQuint);
            TransitionContent.MoveToX(200).MoveToX(0, WaveContainer.APPEAR_DURATION, Easing.OutQuint);
        }

        protected override bool OnExiting(Screen next)
        {
            Content.FadeOut(WaveContainer.DISAPPEAR_DURATION, Easing.OutQuint);
            TransitionContent.MoveToX(200, WaveContainer.DISAPPEAR_DURATION, Easing.OutQuint);

            return base.OnExiting(next);
        }

        protected override void OnResuming(Screen last)
        {
            base.OnResuming(last);

            Content.FadeIn(WaveContainer.APPEAR_DURATION, Easing.OutQuint);
            TransitionContent.MoveToX(0, WaveContainer.APPEAR_DURATION, Easing.OutQuint);
        }

        protected override void OnSuspending(Screen next)
        {
            base.OnSuspending(next);

            Content.FadeOut(WaveContainer.DISAPPEAR_DURATION, Easing.OutQuint);
            TransitionContent.MoveToX(-200, WaveContainer.DISAPPEAR_DURATION, Easing.OutQuint);
        }
    }
}
