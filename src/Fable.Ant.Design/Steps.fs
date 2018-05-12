namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Steps =

    [<StringEnum>]
    type StepsStatus = Wait | Process | Finish | Error

    [<StringEnum>]
    type StepsSize = Default | Small

    [<StringEnum>]
    type StepsDirection = Horizontal | Vertical

    type StepProgressDotInfo = { index:int; status:string; title:string; description:string  }
    
    type StepsProps =
        | PrefixCls of string
        | IconPrefix of string
        | Current of int
        | Status of StepsStatus 
        | Size of  StepsSize
        | Direction of StepsDirection
        | ProgressDot of U2<bool, (React.ReactElement -> StepProgressDotInfo -> React.ReactElement)> /// iconDot, { index, status, title, description }
        //style?: React.CSSProperties;
        interface Fable.Helpers.React.Props.IProp


    type StepProps = 
        //className: PropTypes.string,
        | PrefixCls of string
        //style: PropTypes.object,
        | WrapperStyle of obj
        | ItemWidth of U2<int,string>
        | Status of string
        | IconPrefix of string
        | Icon of React.ReactElement
        | AdjustMarginRight of U2<int, string>
        | StepNumber of string
        | Description of React.ReactElement // obj
        | Title of React.ReactElement // obj
        | ProgressDot of U2<bool, unit->unit>
        | TailContent of obj
        interface Fable.Helpers.React.Props.IProp

    let inline steps (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Steps" "antd" (keyValueList CaseRules.LowerFirst props) children

    let inline step (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Steps.Step" "antd" (keyValueList CaseRules.LowerFirst props) children
