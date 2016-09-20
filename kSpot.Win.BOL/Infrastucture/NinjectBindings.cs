﻿using kSpot.Win.DAL.Context;
using kSpot.Win.DAL.Interfaces;
using Ninject;
using System;

namespace kSpot.Win.BOL.Infrastucture
{
    public static class NinjectBindings
    {
        private static IKernel Kernel = new StandardKernel();

        static NinjectBindings()
        {
            AddBindings();
        }

        /// <summary>
        /// W tej metodzie wstrzykujemy zależności
        /// </summary>
        private static void AddBindings()
        {
            Kernel.Bind<IkSpotContext>().To<kSpotContext>();
        }

        public static T GetInstance<T>(Type serviceType)
        {
            return (T)Kernel.Get(serviceType);
        }
    }
}
