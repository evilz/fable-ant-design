namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

/// https://ant.design/components/input-number/
[<RequireQualifiedAccess>]
module InputNumber =

    type InputSize = Input.InputSize

    type InputNumberProps  =
        | AutoFocus of bool
        | DefaultValue of float
        | Formatter of (float -> string)
        | Max of float
        | Min of float
        | Parser of (string -> float)
        | Precision of float
        | Size of InputSize
        | Step of U2<float,string>
        | Value of float
        | OnChange of (U2<float,string> -> unit)
        interface Fable.Helpers.React.Props.IProp

     let inline inputNumber (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "InputNumber" "antd" (keyValueList CaseRules.LowerFirst props) children
