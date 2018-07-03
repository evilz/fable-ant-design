namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props


[<RequireQualifiedAccess>]
module Calendar =

    [<StringEnum>]
    type CalendarMode =
        | Month
        | Year

    type CalendarProps =
        | PrefixCls of string
        //className?: string;
        | Value of obj // moment.Moment
        | DefaultValue of obj // moment.Moment;
        | Mode of CalendarMode
        | Fullscreen of bool
        | DateCellRender of (obj -> React.ReactElement) // => React.ReactNode;
        | MonthCellRender of (obj -> React.ReactElement) // => React.ReactNode;
        | DateFullCellRender of (obj -> React.ReactElement) // => React.ReactNode;
        | MonthFullCellRender of (obj -> React.ReactElement) //=> React.ReactNode;
        | Locale of obj
        //style?: React.CSSProperties;
        | OnPanelChange of (obj * CalendarMode -> unit)
        | OnSelect of (obj -> unit)
        | DisabledDate of (obj -> bool)
        | ValidRange of obj * obj //[moment.Moment, moment.Moment];
        interface Fable.Helpers.React.Props.IProp

    let inline calendar  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Calendar " "antd" (keyValueList CaseRules.LowerFirst props) children
