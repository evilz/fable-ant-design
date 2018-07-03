namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Table =

    [<StringEnum>]
    type SortOrder = Ascend | Descend
    
    //(a: 'T * b: 'T * sortOrder: SortOrder option) -> int
    type CompareFn<'T> = 'T -> 'T -> SortOrder option -> int

    type ColumnFilterItem = { text: string; value: string; children: ColumnFilterItem[] }

    [<StringEnum>]
    type ColumnAlign = Left | Right | Center

    [<StringEnum>]
    type ColumnFixed = Left | Right
    
    type ColumnProps<'T> =
        | Title of React.ReactElement
        //key?: React.Key;
        | DataIndex of string
        | Render of (obj -> 'T -> int -> React.ReactElement)
        | Align of ColumnAlign
        | Filters of ColumnFilterItem[]
        | OnFilter of (obj -> 'T -> bool)
        | FilterMultiple of bool
        | FilterDropdown of React.ReactElement
        | FilterDropdownVisible of bool
        | OnFilterDropdownVisibleChange of (bool -> unit)
        | Sorter of  U2<bool, CompareFn<'T>>
        | DefaultSortOrder of SortOrder
        | ColSpan of int
        | Width of U2<string,int>
        //|className?: string;
        | Fixed of U2<bool, ColumnFixed>
        | FilterIcon of React.ReactNode
        | FilteredValue of obj[]
        | SortOrder of SortOrder
        //children?: ColumnProps<T>[]
        | OnCellClick of ( 'T-> obj -> unit)
        | OnCell of ('T -> obj)
        | OnHeaderCell of (ColumnProps<'T> -> obj)


// export interface TableComponents {
//   table?: any;
//   header?: {
//     wrapper?: any;
//     row?: any;
//     cell?: any;
//   };
//   body?: {
//     wrapper?: any;
//     row?: any;
//     cell?: any;
//   };
// }

// export interface TableLocale {
//   filterTitle?: string;
//   filterConfirm?: React.ReactNode;
//   filterReset?: React.ReactNode;
//   emptyText?: React.ReactNode | (() => React.ReactNode);
//   selectAll?: React.ReactNode;
//   selectInvert?: React.ReactNode;
// }

    [<StringEnum>]
    type RowSelectionType = Checkbox | Radio

    type SelectionSelectFn<'T> = 'T -> bool -> obj[] -> Browser.Event -> obj

    [<StringEnum>]
    type TablePaginationPosition = Top | Bottom | Both
    type TablePaginationConfig = { //extends PaginationProps {
        position: TablePaginationPosition option
    }

    [<StringEnum>]
    type TableSelectWay = OnSelect | OnSelectAll | OnSelectInvert

    
    type SelectionItemSelectFn = string[] -> obj

    [<Pojo>]
    type SelectionItem = {
          key: string;
          text: React.ReactNode;
          onSelect: SelectionItemSelectFn;
    }

    type TableRowSelection<'T> =
        | Type of RowSelectionType
        | SelectedRowKeys of  U2<string[],int[]>
        | OnChange of (U2<string[],int[]> -> obj[] -> obj)
        | GetCheckboxProps of ('T -> obj)
        | OnSelect of SelectionSelectFn<'T>
        | OnSelectAll of (bool -> obj[] -> obj[] -> obj)
        | OnSelectInvert of (obj[] -> obj)
        | Selections of U2<SelectionItem[],bool>
        | HideDefaultSelections of bool
        | Fixed of bool
        | ColumnWidth of U2<string,int>

    [<StringEnum>]
    type TableSize = Default | Middle | Small
    type TableProps<'T> =
        | PrefixCls of string
        | DropdownPrefixCls of string
        | RowSelection of TableRowSelection<'T>
        | Pagination of U2<TablePaginationConfig,bool> //false;
        | Size of TableSize
        | DataSource of 'T[]
        | Components of TableComponents
  columns?: ColumnProps<T>[];
  rowKey?: string | ((record: T, index: number) => string);
  rowClassName?: (record: T, index: number) => string;
  expandedRowRender?: any;
  defaultExpandAllRows?: boolean;
  defaultExpandedRowKeys?: string[] | number[];
  expandedRowKeys?: string[] | number[];
  expandIconAsCell?: boolean;
  expandIconColumnIndex?: number;
  expandRowByClick?: boolean;
  onExpandedRowsChange?: (expandedRowKeys: string[] | number[]) => void;
  onExpand?: (expanded: boolean, record: T) => void;
  onChange?: (pagination: TablePaginationConfig | boolean, filters: string[], sorter: Object) => any;
  loading?: boolean | SpinProps;
  locale?: Object;
  indentSize?: number;
  onRowClick?: (record: T, index: number, event: Event) => any;
  onRow?: (record: T, index: number) => any;
  onHeaderRow?: (columns: ColumnProps<T>[], index: number) => any;
  useFixedHeader?: boolean;
  bordered?: boolean;
  showHeader?: boolean;
  footer?: (currentPageData: Object[]) => React.ReactNode;
  title?: (currentPageData: Object[]) => React.ReactNode;
  scroll?: { x?: boolean | number | string, y?: boolean | number | string };
  childrenColumnName?: string;
  bodyStyle?: React.CSSProperties;
  className?: string;
  style?: React.CSSProperties;
  children?: React.ReactNode;
}

export interface TableStateFilters {
  [key: string]: string[];
}

export interface TableState<T> {
  pagination: TablePaginationConfig;
  filters: TableStateFilters;
  sortColumn: ColumnProps<T> | null;
  sortOrder: 'ascend' | 'descend' | undefined;
}


export interface SelectionCheckboxAllProps<T> {
  store: Store;
  locale: any;
  disabled: boolean;
  getCheckboxPropsByItem: (item: any, index: number) => any;
  getRecordKey: (record: any, index?: number) => string;
  data: T[];
  prefixCls: string | undefined;
  onSelect: (key: string, index: number, selectFunc: any) => void;
  hideDefaultSelections?: boolean;
  selections?: SelectionItem[] | boolean;
  getPopupContainer: (triggerNode?: Element) => HTMLElement;
}

export interface SelectionCheckboxAllState {
  checked: boolean;
  indeterminate: boolean;
}

export interface SelectionBoxProps {
  store: Store;
  type?: RowSelectionType;
  defaultSelection: string[];
  rowIndex: string;
  name?: string;
  disabled?: boolean;
  onChange: (e: RadioChangeEvent | CheckboxChangeEvent) => void;
}

export interface SelectionBoxState {
  checked?: boolean;
}

export interface SelectionInfo<T> {
  selectWay: TableSelectWay;
  record?: T;
  checked?: boolean;
  changeRowKeys?: React.Key[];
  nativeEvent?: Event;
}

export interface FilterMenuProps<T> {
  locale: TableLocale;
  selectedKeys: string[];
  column: ColumnProps<T>;
  confirmFilter: (column: ColumnProps<T>, selectedKeys: string[]) => any;
  prefixCls: string;
  dropdownPrefixCls: string;
  getPopupContainer: (triggerNode?: Element) => HTMLElement;
}

export interface FilterMenuState {
  selectedKeys: string[];
  keyPathOfSelectedItem: { [key: string]: string };
  visible?: boolean;
}

    [<StringEnum>]
    type TableSize = Small | Default

    type SwitchProps =
        | PrefixCls of string
        interface Fable.Helpers.React.Props.IProp

    let inline table (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Table" "antd" (keyValueList CaseRules.LowerFirst props) children