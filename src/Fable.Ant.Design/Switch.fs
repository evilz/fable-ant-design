namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Switch =

    [<StringEnum>]
    type SwitchSize = Small | Default

    type SwitchProps =
        | PrefixCls of string
        | Size of SwitchSize
        | ClassName of string
        | Checked of bool
        | DefaultChecked of bool
        | OnChange of (bool -> unit)
        | CheckedChildren of  React.ReactElement // React.ReactNode
        | UnCheckedChildren of React.ReactElement  // React.ReactNode
        | Disabled of bool
        | Loading of bool
        interface Fable.Helpers.React.Props.IProp

    let inline switch (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Switch" "antd" (keyValueList CaseRules.LowerFirst props) children
