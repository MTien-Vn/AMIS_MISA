﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Misa.BL.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Misa.BL.Properties.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không xóa được.
        /// </summary>
        public static string Error_Delete {
            get {
                return ResourceManager.GetString("Error_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email đã tồn tại.
        /// </summary>
        public static string Error_DuplicateEmail {
            get {
                return ResourceManager.GetString("Error_DuplicateEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã nhân viên đã tồn tại.
        /// </summary>
        public static string Error_DuplicateEmployeeCode {
            get {
                return ResourceManager.GetString("Error_DuplicateEmployeeCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số CMTND/thẻ căn cước đã tồn tại.
        /// </summary>
        public static string Error_DuplicateEmployeeIDCard {
            get {
                return ResourceManager.GetString("Error_DuplicateEmployeeIDCard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Mã số thuế cá nhân đã tồn tại.
        /// </summary>
        public static string Error_DuplicateEmployTaxCode {
            get {
                return ResourceManager.GetString("Error_DuplicateEmployTaxCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Số điện thoại đã tồn tại.
        /// </summary>
        public static string Error_DuplicatePhoneNumber {
            get {
                return ResourceManager.GetString("Error_DuplicatePhoneNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không được để trống.
        /// </summary>
        public static string Error_EmptyFiled {
            get {
                return ResourceManager.GetString("Error_EmptyFiled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không tồn tại.
        /// </summary>
        public static string Error_NotExist {
            get {
                return ResourceManager.GetString("Error_NotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vui lòng liên hệ Misa để nhận trợ giúp.
        /// </summary>
        public static string Exception_User_Mess {
            get {
                return ResourceManager.GetString("Exception_User_Mess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thành công.
        /// </summary>
        public static string Success {
            get {
                return ResourceManager.GetString("Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đã xóa thành công.
        /// </summary>
        public static string Success_Delete {
            get {
                return ResourceManager.GetString("Success_Delete", resourceCulture);
            }
        }
    }
}
