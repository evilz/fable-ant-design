namespace Navigation.Steps

open Fable.Core
open Fable.Core.JsInterop
open Elmish
open Fable.AntD
open DemoCard.Types

module Types =

    [<StringEnum>]
    type PaginationDemos = Basic | MiniVersion | WithIcon | SwitchStep | Vertical | VerticalMini | ErrorStatus | DotStyle | CustomizedDotStyle


    type Model = {
      tabs: Map<PaginationDemos,DemoCard.Types.Tab>
      current: int
    }

    type Msg =
      | ChangeTabMsg of PaginationDemos * DemoCard.Types.Tab
      | NextMsg 
      | PrevMsg 

open Types

module State =

    let init () : Model * Cmd<Msg> =
      let tabs = [Basic; MiniVersion; WithIcon; SwitchStep; Vertical; VerticalMini; ErrorStatus; DotStyle; CustomizedDotStyle]
                  |> List.map (fun x->x,DemoCard.Types.Demo) 
                  |>  Map.ofList 
                  
      {tabs = tabs; current = 0 }, Cmd.Empty

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg (demo,tab) -> {model with tabs = model.tabs.Add(demo, tab)}, []
       | NextMsg -> {model with current = model.current + 1}, []
       | PrevMsg -> {model with current = model.current - 1}, []

module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    
    importAll "./Steps.less"  
           
    let root (model:Model) (dispatch:Msg->unit) =
      let demos =
        [|
          Basic, { title = "Basic" ; 
            demo = Navigation.Steps.StepsBasic.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsBasic.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          MiniVersion, { title = "Mini version" ; 
            demo = Navigation.Steps.StepsMiniVersion.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsMiniVersion.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          WithIcon, { title = "With icon" ; 
            demo = Navigation.Steps.StepsWithIcon.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsWithIcon.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          SwitchStep, { title = "Switch step" ; 
            demo = Navigation.Steps.StepsSwitchStep.view model.current (fun () -> NextMsg |> dispatch) (fun () -> PrevMsg |> dispatch); 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsSwitchStep.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          Vertical, { title = "Vertical" ; 
            demo = Navigation.Steps.StepsVertical.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsVertical.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          VerticalMini, { title = "Vertical mini" ; 
            demo = Navigation.Steps.StepsVerticalMini.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsVerticalMini.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          ErrorStatus, { title = "Error status" ; 
            demo = Navigation.Steps.StepsErrorStatus.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsErrorStatus.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          DotStyle, { title = "Dot style" ; 
            demo = Navigation.Steps.StepsDotStyle.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsDotStyle.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
          CustomizedDotStyle, { title = "Customize dot style" ; 
            demo = Navigation.Steps.StepsCustomizedDotStyle.view; 
            source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_StepsCustomizedDotStyle.fs"; 
            activeTab = DemoCard.Types.Demo 
          }
        |] |> Map.ofArray
//   CustomizedDotStyle

      let renderDemo demo  = 
        DemoCard.View.root {demos.[demo] with activeTab = model.tabs.[demo] }  (fun msg -> ChangeTabMsg (demo, msg) |> dispatch  ) 
     

      div [ ClassName "steps-demo"  ] [
        yield h1 [] [str "Steps"] 
        yield! ([ Basic; MiniVersion; WithIcon; SwitchStep;Vertical; VerticalMini; ErrorStatus; DotStyle;CustomizedDotStyle] |> List.map renderDemo)
      ]
