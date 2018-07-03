namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

/// import declarations for `InputNumber` and its nested components.
/// For more information, refer to the [official documentation](https://ant.design/components/input-number/)
[<RequireQualifiedAccess>]
module InputNumber =
    
    type Value = U2<float,string>
   
    type InputNumberProps  =
        /// get focus when component mounted
        | AutoFocus of bool
        /// initial value	
        | DefaultValue of float
        /// disable the input	
        | Disabled of bool
        /// Specifies the format of the value presented
        | Formatter of (Value -> string)
        /// max value
        | Max of float
        /// min value	
        | Min of float
        /// Specifies the value extracted from formatter
        | Parser of (string -> float)
        /// precision of input value
        | Precision of float
        /// width of input box
        | Size of Common.Size
        /// The number to which the current value is increased or decreased. 
        /// It can be an integer or decimal.
        | Step of Value
        /// current value
        | Value of float
        /// The callback triggered when the value is changed.
        | OnChange of (Value -> unit)
        interface Fable.Helpers.React.Props.IProp

     let inline inputNumber (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "InputNumber" "antd" (keyValueList CaseRules.LowerFirst props) children
