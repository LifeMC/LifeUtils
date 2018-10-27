#region Header

// 
//        LifeUtils - LifeUtils - Annotations.cs
//                  27.10.2018 08:06

#endregion

namespace LifeUtils.Annotations
{
    #region Imports

    using System;

    #endregion

    public static class Annotations
    {
        public static void Init(Type type, IConfigFile config)
        {
            LocalizableAttribute.Init(type, config);
            ConfigurableAttribute.Init(type, config);
        }
    }
}