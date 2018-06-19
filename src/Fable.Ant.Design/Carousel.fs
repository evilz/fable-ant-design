namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser

[<RequireQualifiedAccess>]
module Carousel =

    [<StringEnum>]
    type CarouselEffect = Scrollx | Fade

    type CarouselProps =
        | Effect of CarouselEffect
        | Dots of bool
        | Vertical of bool
        | Autoplay of bool
        | Easing of string
        | BeforeChange of (int * int -> unit) //(from: number, to: number) => void
        | AfterChange of (int -> unit) //(current: number) => void
        //| style of React.CSSProperties
        | PrefixCls of string
        | Accessibility of bool
        | NextArrow of U2<HTMLElement,obj>
        | PrevArrow of U2<HTMLElement,obj>
        | PauseOnHover of bool
        //| className of string
        | AdaptiveHeight of bool
        | Arrows of bool
        | AutoplaySpeed of float
        | CenterMode of bool
        | CenterPadding of U2<string, obj>
        | CssEase of U2<string, obj>
        | DotsClass of string
        | Draggable of bool
        | Fade of bool
        | FocusOnSelect of bool
        | Infinite of bool
        | InitialSlide of int
        | LazyLoad of bool
        | Rtl of bool
        | Slide of string
        | SlidesToShow of int
        | SlidesToScroll of int
        | Speed of float
        | Swipe of bool
        | SwipeToSlide of bool
        | TouchMove of bool
        | TouchThreshold of float
        | VariableWidth of bool
        | UseCSS of bool
        | SlickGoTo of float

    let inline carousel (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Carousel" "antd" (keyValueList CaseRules.LowerFirst props) children
