// <auto-generated />
#if !EXCLUDE_CODEGEN
#pragma warning disable 162
#pragma warning disable 219
#pragma warning disable 414
#pragma warning disable 618
#pragma warning disable 649
#pragma warning disable 693
#pragma warning disable 1591
#pragma warning disable 1998
[assembly: global::Orleans.Metadata.FeaturePopulatorAttribute(typeof(OrleansGeneratedCode.OrleansCodeGen9ae98b6c82FeaturePopulator))]
[assembly: global::Orleans.CodeGeneration.OrleansCodeGenerationTargetAttribute(@"Implements, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
namespace OrleansGeneratedCode1541EBBF
{
    using global::Orleans;
    using global::System.Reflection;
}

namespace OrleansGeneratedCode
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute(@"Orleans-CodeGenerator", @"2.0.0.0")]
    internal sealed class OrleansCodeGen9ae98b6c82FeaturePopulator : global::Orleans.Metadata.IFeaturePopulator<global::Orleans.Metadata.GrainInterfaceFeature>, global::Orleans.Metadata.IFeaturePopulator<global::Orleans.Metadata.GrainClassFeature>, global::Orleans.Metadata.IFeaturePopulator<global::Orleans.Serialization.SerializerFeature>
    {
        public void Populate(global::Orleans.Metadata.GrainInterfaceFeature feature)
        {
        }

        public void Populate(global::Orleans.Metadata.GrainClassFeature feature)
        {
            feature.Classes.Add(new global::Orleans.Metadata.GrainClassMetadata(typeof(global::Implements.RateLimit)));
        }

        public void Populate(global::Orleans.Serialization.SerializerFeature feature)
        {
            feature.AddKnownType(@"Interop,System.Runtime.Extensions", @"Interop");
            feature.AddKnownType(@"Interop+Secur32,System.Runtime.Extensions", @"Secur32");
            feature.AddKnownType(@"Interop+Shell32,System.Runtime.Extensions", @"Shell32");
            feature.AddKnownType(@"Interop+BOOLEAN,System.Runtime.Extensions", @"BOOLEAN");
            feature.AddKnownType(@"Interop+Advapi32,System.Runtime.Extensions", @"Advapi32");
            feature.AddKnownType(@"Interop+Kernel32,System.Runtime.Extensions", @"Kernel32");
            feature.AddKnownType(@"Interop+Kernel32+OSVERSIONINFOEX,System.Runtime.Extensions", @"OSVERSIONINFOEX");
            feature.AddKnownType(@"Interop+Kernel32+SYSTEM_INFO,System.Runtime.Extensions", @"SYSTEM_INFO");
            feature.AddKnownType(@"FxResources.System.Runtime.Extensions.SR,System.Runtime.Extensions", @"FxResources.System.Runtime.Extensions.SR");
            feature.AddKnownType(@"System.PasteArguments,System.Runtime.Extensions", @"PasteArguments");
            feature.AddKnownType(@"System.AppDomain,System.Runtime.Extensions", @"AppDomain");
            feature.AddKnownType(@"System.AppDomainUnloadedException,System.Runtime.Extensions", @"AppDomainUnloadedException");
            feature.AddKnownType(@"System.ApplicationId,System.Runtime.Extensions", @"ApplicationId");
            feature.AddKnownType(@"System.CannotUnloadAppDomainException,System.Runtime.Extensions", @"CannotUnloadAppDomainException");
            feature.AddKnownType(@"System.ContextBoundObject,System.Runtime.Extensions", @"ContextBoundObject");
            feature.AddKnownType(@"System.ContextMarshalException,System.Runtime.Extensions", @"ContextMarshalException");
            feature.AddKnownType(@"System.ContextStaticAttribute,System.Runtime.Extensions", @"ContextStaticAttribute");
            feature.AddKnownType(@"System.Environment,System.Runtime.Extensions", @"Environment");
            feature.AddKnownType(@"System.Environment+SpecialFolder,System.Runtime.Extensions", @"Environment.SpecialFolder");
            feature.AddKnownType(@"System.Environment+SpecialFolderOption,System.Runtime.Extensions", @"Environment.SpecialFolderOption");
            feature.AddKnownType(@"System.LoaderOptimization,System.Runtime.Extensions", @"LoaderOptimization");
            feature.AddKnownType(@"System.LoaderOptimizationAttribute,System.Runtime.Extensions", @"LoaderOptimizationAttribute");
            feature.AddKnownType(@"System.OperatingSystem,System.Runtime.Extensions", @"OperatingSystem");
            feature.AddKnownType(@"System.PlatformID,System.Runtime.Extensions", @"PlatformID");
            feature.AddKnownType(@"System.StringNormalizationExtensions,System.Runtime.Extensions", @"StringNormalizationExtensions");
            feature.AddKnownType(@"System.SR,System.Runtime.Extensions", @"SR");
            feature.AddKnownType(@"System.Text.ValueStringBuilder,System.Runtime.Extensions", @"ValueStringBuilder");
            feature.AddKnownType(@"System.Threading.Tasks.TaskToApm,System.Runtime.Extensions", @"TaskToApm");
            feature.AddKnownType(@"System.Security.IPermission,System.Runtime.Extensions", @"IPermission");
            feature.AddKnownType(@"System.Security.ISecurityEncodable,System.Runtime.Extensions", @"ISecurityEncodable");
            feature.AddKnownType(@"System.Security.ISecurityElementFactory,System.Runtime.Extensions", @"ISecurityElementFactory");
            feature.AddKnownType(@"System.Security.SecurityElement,System.Runtime.Extensions", @"SecurityElement");
            feature.AddKnownType(@"System.Security.Permissions.CodeAccessSecurityAttribute,System.Runtime.Extensions", @"CodeAccessSecurityAttribute");
            feature.AddKnownType(@"System.Security.Permissions.SecurityAttribute,System.Runtime.Extensions", @"SecurityAttribute");
            feature.AddKnownType(@"System.Security.Permissions.SecurityAction,System.Runtime.Extensions", @"SecurityAction");
            feature.AddKnownType(@"System.Security.Permissions.SecurityPermissionAttribute,System.Runtime.Extensions", @"SecurityPermissionAttribute");
            feature.AddKnownType(@"System.Security.Permissions.SecurityPermissionFlag,System.Runtime.Extensions", @"SecurityPermissionFlag");
            feature.AddKnownType(@"System.Collections.ArrayList,System.Runtime.Extensions", @"ArrayList");
            feature.AddKnownType(@"System.Collections.ArrayList+ArrayListDebugView,System.Runtime.Extensions", @"ArrayListDebugView");
            feature.AddKnownType(@"System.Collections.Hashtable,System.Runtime.Extensions", @"Hashtable");
            feature.AddKnownType(@"System.Collections.Hashtable+HashtableDebugView,System.Runtime.Extensions", @"HashtableDebugView");
            feature.AddKnownType(@"System.Collections.CompatibleComparer,System.Runtime.Extensions", @"CompatibleComparer");
            feature.AddKnownType(@"System.Collections.IHashCodeProvider,System.Runtime.Extensions", @"IHashCodeProvider");
            feature.AddKnownType(@"System.Collections.KeyValuePairs,System.Runtime.Extensions", @"KeyValuePairs");
            feature.AddKnownType(@"System.Collections.HashHelpers,System.Runtime.Extensions", @"HashHelpers");
            feature.AddKnownType(@"System.Collections.Generic.LowLevelDictionary`2,System.Runtime.Extensions", @"LowLevelDictionary`2'2");
            feature.AddKnownType(@"System.Runtime.Versioning.FrameworkName,System.Runtime.Extensions", @"FrameworkName");
            feature.AddKnownType(@"System.Runtime.Versioning.ComponentGuaranteesAttribute,System.Runtime.Extensions", @"ComponentGuaranteesAttribute");
            feature.AddKnownType(@"System.Runtime.Versioning.ResourceConsumptionAttribute,System.Runtime.Extensions", @"ResourceConsumptionAttribute");
            feature.AddKnownType(@"System.Runtime.Versioning.ComponentGuaranteesOptions,System.Runtime.Extensions", @"ComponentGuaranteesOptions");
            feature.AddKnownType(@"System.Runtime.Versioning.ResourceExposureAttribute,System.Runtime.Extensions", @"ResourceExposureAttribute");
            feature.AddKnownType(@"System.Runtime.Versioning.ResourceScope,System.Runtime.Extensions", @"ResourceScope");
            feature.AddKnownType(@"System.Runtime.Versioning.SxSRequirements,System.Runtime.Extensions", @"SxSRequirements");
            feature.AddKnownType(@"System.Runtime.Versioning.VersioningHelper,System.Runtime.Extensions", @"VersioningHelper");
            feature.AddKnownType(@"System.Reflection.AssemblyNameProxy,System.Runtime.Extensions", @"AssemblyNameProxy");
            feature.AddKnownType(@"System.Net.WebUtility,System.Runtime.Extensions", @"WebUtility");
            feature.AddKnownType(@"System.IO.StringReader,System.Runtime.Extensions", @"StringReader");
            feature.AddKnownType(@"System.IO.StringWriter,System.Runtime.Extensions", @"StringWriter");
            feature.AddKnownType(@"System.IO.BufferedStream,System.Runtime.Extensions", @"BufferedStream");
            feature.AddKnownType(@"System.IO.InvalidDataException,System.Runtime.Extensions", @"InvalidDataException");
            feature.AddKnownType(@"System.IO.StreamHelpers,System.Runtime.Extensions", @"StreamHelpers");
            feature.AddKnownType(@"System.IO.StringBuilderCache,System.Runtime.Extensions", @"StringBuilderCache");
            feature.AddKnownType(@"System.IO.Win32Marshal,System.Runtime.Extensions", @"Win32Marshal");
            feature.AddKnownType(@"System.IO.DriveInfoInternal,System.Runtime.Extensions", @"DriveInfoInternal");
            feature.AddKnownType(@"System.IO.PathHelper,System.Runtime.Extensions", @"PathHelper");
            feature.AddKnownType(@"System.IO.PathInternal,System.Runtime.Extensions", @"PathInternal");
            feature.AddKnownType(@"System.Diagnostics.Stopwatch,System.Runtime.Extensions", @"Stopwatch");
            feature.AddKnownType(@"System.CodeDom.Compiler.IndentedTextWriter,System.Runtime.Extensions", @"IndentedTextWriter");
            feature.AddKnownType(@"Interop,System.Console", @"Interop");
            feature.AddKnownType(@"Interop+Kernel32,System.Console", @"Kernel32");
            feature.AddKnownType(@"Interop+Kernel32+CONSOLE_CURSOR_INFO,System.Console", @"CONSOLE_CURSOR_INFO");
            feature.AddKnownType(@"Interop+Kernel32+CONSOLE_SCREEN_BUFFER_INFO,System.Console", @"CONSOLE_SCREEN_BUFFER_INFO");
            feature.AddKnownType(@"Interop+Kernel32+COORD,System.Console", @"COORD");
            feature.AddKnownType(@"Interop+Kernel32+SMALL_RECT,System.Console", @"SMALL_RECT");
            feature.AddKnownType(@"Interop+Kernel32+Color,System.Console", @"Color");
            feature.AddKnownType(@"Interop+Kernel32+CHAR_INFO,System.Console", @"CHAR_INFO");
            feature.AddKnownType(@"Interop+Kernel32+ConsoleCtrlHandlerRoutine,System.Console", @"ConsoleCtrlHandlerRoutine");
            feature.AddKnownType(@"Interop+BOOL,System.Console", @"BOOL");
            feature.AddKnownType(@"Interop+User32,System.Console", @"User32");
            feature.AddKnownType(@"Interop+KeyEventRecord,System.Console", @"KeyEventRecord");
            feature.AddKnownType(@"Interop+InputRecord,System.Console", @"InputRecord");
            feature.AddKnownType(@"FxResources.System.Console.SR,System.Console", @"FxResources.System.Console.SR");
            feature.AddKnownType(@"System.Console,System.Console", @"Console");
            feature.AddKnownType(@"System.ConsoleCancelEventHandler,System.Console", @"ConsoleCancelEventHandler");
            feature.AddKnownType(@"System.ConsoleCancelEventArgs,System.Console", @"ConsoleCancelEventArgs");
            feature.AddKnownType(@"System.ConsoleColor,System.Console", @"ConsoleColor");
            feature.AddKnownType(@"System.ConsoleSpecialKey,System.Console", @"ConsoleSpecialKey");
            feature.AddKnownType(@"System.ConsoleKey,System.Console", @"ConsoleKey");
            feature.AddKnownType(@"System.ConsoleKeyInfo,System.Console", @"ConsoleKeyInfo");
            feature.AddKnownType(@"System.ConsoleModifiers,System.Console", @"ConsoleModifiers");
            feature.AddKnownType(@"System.ConsolePal,System.Console", @"ConsolePal");
            feature.AddKnownType(@"System.ConsolePal+ControlKeyState,System.Console", @"ControlKeyState");
            feature.AddKnownType(@"System.IO.ConsoleStream,System.Console", @"ConsoleStream");
            feature.AddKnownType(@"System.ConsolePal+ControlCHandlerRegistrar,System.Console", @"ControlCHandlerRegistrar");
            feature.AddKnownType(@"System.SR,System.Console", @"SR");
            feature.AddKnownType(@"System.Text.ConsoleEncoding,System.Console", @"ConsoleEncoding");
            feature.AddKnownType(@"System.Text.OSEncoding,System.Console", @"OSEncoding");
            feature.AddKnownType(@"System.Text.OSEncoder,System.Console", @"OSEncoder");
            feature.AddKnownType(@"System.Text.DecoderDBCS,System.Console", @"DecoderDBCS");
            feature.AddKnownType(@"System.Text.EncodingHelper,System.Console", @"EncodingHelper");
            feature.AddKnownType(@"System.IO.SyncTextReader,System.Console", @"SyncTextReader");
            feature.AddKnownType(@"System.IO.SyncTextWriter,System.Console", @"SyncTextWriter");
            feature.AddKnownType(@"System.IO.Error,System.Console", @"Error");
            feature.AddKnownType(@"System.IO.Win32Marshal,System.Console", @"Win32Marshal");
            feature.AddKnownType(@"Implements.RateLimit,Implements", @"Implements.RateLimit");
        }
    }
}
#pragma warning restore 162
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 649
#pragma warning restore 693
#pragma warning restore 1591
#pragma warning restore 1998
#endif
