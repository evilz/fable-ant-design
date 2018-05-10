namespace Navigation.Pagination

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types

module Types =

    [<StringEnum>]
    type PaginationDemos = Basic | More | Changer | Jumper | MiniSize | SimpleMode | Controlled | TotalNumber | PrevNext


    type Model = {
      tabs: Map<PaginationDemos,DemoCard.Types.Tab>
      current : int
    }

    type Msg =
      | ChangeTabMsg of PaginationDemos * DemoCard.Types.Tab
      | ChangePageMsg of int

open Types

module State =

    let init () : Model * Cmd<Msg> =
      let tabs = [Basic; More; Changer; Jumper; MiniSize; SimpleMode; Controlled; TotalNumber; PrevNext ]
                  |> List.map (fun x->x,DemoCard.Types.Demo) 
                  |>  Map.ofList 
                  
      {tabs = tabs; current = 3 }, Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> {model with tabs = model.tabs.Add(demo, tab)}, []
       | ChangePageMsg current -> {model with current = current}, []

module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props

           
    let root (model:Model) (dispatch:Msg->unit) =

      let demos =
        [|
          Basic, { title = "Basic" ; 
            demo = Navigation.Pagination.PaginationBasic.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationBasic.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          More, { title = "More" ; 
            demo = Navigation.Pagination.PaginationMore.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationMore.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Changer, { title = "Changer" ; 
            demo = Navigation.Pagination.PaginationChanger.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationChanger.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Jumper, { title = "Jumper" ; 
            demo = Navigation.Pagination.PaginationJumper.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationJumper.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          MiniSize, { title = "Mini size" ; 
            demo = Navigation.Pagination.PaginationMiniSize.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationMiniSize.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          SimpleMode, { title = "Simple mode" ; 
            demo = Navigation.Pagination.PaginationSimpleMode.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationSimpleMode.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Controlled , { title = "Controlled" ; 
            demo = Navigation.Pagination.PaginationControlled.view model.current (ChangePageMsg >> dispatch) ; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationControlled.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          TotalNumber , { title = "Total number" ; 
            demo = Navigation.Pagination.PaginationTotalNumber.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationTotalNumber.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          PrevNext, { title = "Prev and next" ; 
            demo = Navigation.Pagination.PaginationPrevNext.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_PaginationPrevNext.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray

      let renderDemo demo  = 
        DemoCard.View.root {demos.[demo] with activeTab = model.tabs.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
     

      div [ ClassName "pagination-demo"  ] [
        yield h1 [] [str "Pagination"] 
        yield! ([ Basic; More; Changer; Jumper; MiniSize; SimpleMode; Controlled; TotalNumber; PrevNext ] |> List.map renderDemo)
      ]
