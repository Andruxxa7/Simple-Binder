﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleBinder.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SimpleBinder.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error.
        /// </summary>
        internal static string Caption_Error {
            get {
                return ResourceManager.GetString("Caption_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you wanna save binds before exit?.
        /// </summary>
        internal static string exitToolStripMenuItem_Click_Text {
            get {
                return ResourceManager.GetString("exitToolStripMenuItem_Click_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning.
        /// </summary>
        internal static string exitToolStripMenuItem_Click_Warning {
            get {
                return ResourceManager.GetString("exitToolStripMenuItem_Click_Warning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save a Config(Json) File.
        /// </summary>
        internal static string exportToolStripMenuItem_Click {
            get {
                return ResourceManager.GetString("exportToolStripMenuItem_Click", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open a Config(Json) File.
        /// </summary>
        internal static string importStripMenuItem_Text {
            get {
                return ResourceManager.GetString("importStripMenuItem_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Json config|*.json.
        /// </summary>
        internal static string importStripMenuItemClick_Json_config {
            get {
                return ResourceManager.GetString("importStripMenuItemClick_Json_config", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Something gone wrong with parsing values from your config(.json).
        /// </summary>
        internal static string ParseFromJsonToWinForms_Error_Message {
            get {
                return ResourceManager.GetString("ParseFromJsonToWinForms_Error_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you wanna close binder?.
        /// </summary>
        internal static string SimpleBinder_Binder_FormClosing_Text {
            get {
                return ResourceManager.GetString("SimpleBinder_Binder_FormClosing_Text", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Turn Off.
        /// </summary>
        internal static string statusButton_Turn_Off {
            get {
                return ResourceManager.GetString("statusButton_Turn_Off", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Turn On.
        /// </summary>
        internal static string statusButton_Turn_On {
            get {
                return ResourceManager.GetString("statusButton_Turn_On", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bind cannot be registered. There is another such bind but already registered. Number of bind with problem is .
        /// </summary>
        internal static string TurnOnBinder_Error_Message {
            get {
                return ResourceManager.GetString("TurnOnBinder_Error_Message", resourceCulture);
            }
        }
    }
}
