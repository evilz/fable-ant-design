namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

/// import declarations for `Select` and its nested components.
/// For more information, refer to the [official documentation](https://ant.design/components/select/)
[<RequireQualifiedAccess>]
module Select =

    type OptionProps =
        | Disabled of bool
        | Key of string
        | Title of string
        | Value of U2<string,float>
        interface Fable.Helpers.React.Props.IProp

    let inline option (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Select.Option" "antd" (keyValueList CaseRules.LowerFirst props) children

    type OptGroupProps =
        | Key of string
        | Value of U2<string,React.ReactElement>
        interface Fable.Helpers.React.Props.IProp

    let inline optGroup (props: IProp list) (children: React.ReactElement list): React.ReactElement =
        ofImport "Select.OptGroup" "antd" (keyValueList CaseRules.LowerFirst props) children

    [<StringEnum>]
    type SelectMode  =
        | Multiple
        | Combobox
        | [<CompiledName("tags")>] Tag
        | Default

    type OptionValue = U4<string,float,string list,float list>

    type SelectProps =
        /// Show clear button. Default = false
        | AllowClear of bool
        /// Get focus by default. Default = false
        | AutoFocus of bool
        /// Whether active first option by default. Default = true
        | DefaultActiveFirstOption of bool
        /// Initial selected option.
        | DefaultValue of OptionValue
        /// Whether disabled select. Default = false
        | Disabled of bool
        /// className of dropdown menu
        | DropdownClassName of string
        /// Whether dropdown's with is same with select. Default = true
        | DropdownMatchSelectWidth of bool
        /// If true, filter options by input, if function, filter options against it.
        /// The function will receive two arguments, inputValue and option,
        /// if the function returns true, the option will be included in the filtered set;
        /// Otherwise, it will be excluded. Default = true
        | FilterOption of U2<bool, OptionValue -> OptionValue -> bool>
        /// Value of action option by default
        | FirstActiveValue of U2<string,string list>
        /// Parent Node which the selector should be rendered to. Default to body.
        /// When position issues happen, try to modify it into scrollable content and position it relative.
        /// [Example](https://codesandbox.io/s/4j168r7jw0)
        | GetPopupContainer of (React.ReactNode -> unit)
        /// whether to embed label in value, turn the format of value
        /// from `string` to `{key: string, label: ReactNode}`. Default: false
        | LabelInValue of bool
        /// Max tag count to show
        | MaxTagCount of float
        /// Placeholder for not showing tags. Can be a replacement node or
        /// a compensation function that works on ommited values
        | MaxTagPlaceholder of U2<React.ReactNode,(OptionValue list -> unit)>
        /// Set mode of Select (Support after 2.9)
        | Mode of SelectMode
        /// Specify content to show when no result matches.
        /// Default: 'Not Found'
        | NotFoundContent of string
        /// Which prop value of option will be used for filter if filterOption is true
        | OptionFilterProp of string
        | OptionLabelProp of string
        /// Placeholder of select
        | Placeholder of U2<string,React.ReactNode>
        /// Whether show search input in single mode.
        | ShowSearch of bool
        /// Whether to show the drop-down arrow
        | ShowArrow of bool
        /// Size of Select input
        | Size of Common.Size
        /// Separator used to tokenize on tag/multiple mode
        | TokenSeparators of string list
        /// Current selected option.
        | Value of OptionValue
        /// Called when blur
        | OnBlur of (unit -> unit)
        /// Called when select an option or input value change, or value of input
        /// is changed in combobox mode
        | OnChange of (OptionValue list -> unit)
        /// Called when a option is deselected, the params are option's value (or key).
        /// only called for multiple or tags, effective in multiple or tags mode only.
        | OnDeselect of (OptionValue -> unit)
        /// Called when focus
        | OnFocus of (unit -> unit)
        /// Called when key pressed
        | OnInputKeyDown of (React.KeyboardEvent -> unit)
        /// Called when mouse enter
        | OnMouseEnter of (React.MouseEvent -> unit)
        /// Called when mouse leave
        | OnMouseLeave of (React.MouseEvent -> unit)
        /// Called when dropdown scrolls
        | OnPopupScroll of (unit -> unit)
        /// Callback function that is fired when input changed.
        | OnSearch of (string -> unit)
        | OnSelect of (OptionValue -> unit)
        interface Fable.Helpers.React.Props.IProp

      let inline select (props: IProp list) (children: React.ReactElement list): React.ReactElement =
        ofImport "Select" "antd" (keyValueList CaseRules.LowerFirst props) children
