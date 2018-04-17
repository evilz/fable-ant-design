namespace General.Icons

open Elmish

module Types =
    type Model = DemoCard.Types.Tab

    type Msg =
      | ChangeTabMsg of DemoCard.Types.Tab

open Types
open Fable.Core.JsInterop


module State =

    let init () : Model * Cmd<Msg> =
      DemoCard.Types.Demo , []

    let update msg (model:Model) : Model * Cmd<Msg> =
       match msg with
       | ChangeTabMsg tab -> tab , []



module View =

    open Fable.Helpers.React
    open Fable.Helpers.React.Props
    open Fable.AntD

    let direction = 
      ["step-backward"; "step-forward"; "fast-backward"; "fast-forward"; "shrink"; "arrows-alt"; "down"; "up"; "left"; "right"; "caret-up"; "caret-down"; "caret-left"; "caret-right"; "up-circle"; "down-circle"; "left-circle"; "right-circle"; "up-circle-o"; "down-circle-o"; "right-circle-o"; "left-circle-o"; "double-right"; "double-left"; "verticle-left"; "verticle-right"; "forward"; "backward"; "rollback"; "enter"; "retweet"; "swap"; "swap-left"; "swap-right"; "arrow-up"; "arrow-down"; "arrow-left"; "arrow-right"; "play-circle"; "play-circle-o"; "up-square"; "down-square"; "left-square"; "right-square"; "up-square-o"; "down-square-o"; "left-square-o"; "right-square-o"; "login"; "logout"; "menu-fold"; "menu-unfold"] 
    let suggestion = ["question"; "question-circle-o"; "question-circle"; "plus"; "plus-circle-o"; "plus-circle"; "pause"; "pause-circle-o"; "pause-circle"; "minus"; "minus-circle-o"; "minus-circle"; "plus-square"; "plus-square-o"; "minus-square"; "minus-square-o"; "info"; "info-circle-o"; "info-circle"; "exclamation"; "exclamation-circle-o"; "exclamation-circle"; "close"; "close-circle"; "close-circle-o"; "close-square"; "close-square-o"; "check"; "check-circle"; "check-circle-o"; "check-square"; "check-square-o"; "clock-circle-o"; "clock-circle"; "warning"]
    let logo = [
               "android"; "android-o"; "apple"; "apple-o"; "windows"; "windows-o"; "ie"; "chrome"; "github"; "aliwangwang"; "aliwangwang-o"; "dingding"; "dingding-o";
               "weibo-square"; "weibo-circle"; "taobao-circle"; "html5"; "weibo"; "twitter"; "wechat"; "youtube"; "alipay-circle"; "taobao"; "skype"; "qq"; "medium-workmark"; "gitlab"; "medium"; "linkedin"; "google-plus";
               "dropbox"; "facebook"; "codepen"; "amazon"; "google"; "codepen-circle"; "alipay"; "ant-design"; "aliyun"; "zhihu"; "slack"; "slack-square"; "behance"; "behance-square"; "dribbble"; "dribbble-square"; "instagram"; "yuque";
             ]
    let application = ["lock"; "unlock"; "area-chart"; "pie-chart"; "bar-chart"; "dot-chart"; "bars"; "book"; "calendar"; "cloud"; "cloud-download"; "code"; "code-o"; "copy"; "credit-card"; "delete"; "desktop"; "download"; "edit"; "ellipsis"; "file"; "file-text"; "file-unknown"; "file-pdf"; "file-word"; "file-excel"; "file-jpg"; "file-ppt"; "file-markdown"; "file-add"; "folder"; "folder-open"; "folder-add"; "hdd"; "frown"; "frown-o"; "meh"; "meh-o"; "smile"; "smile-o"; "inbox"; "laptop"; "appstore-o"; "appstore"; "line-chart"; "link"; "mail"; "mobile"; "notification"; "paper-clip"; "picture"; "poweroff"; "reload"; "search"; "setting"; "share-alt"; "shopping-cart"; "tablet"; "tag"; "tag-o"; "tags"; "tags-o"; "to-top"; "upload"; "user"; "video-camera"; "home"; "loading"; "loading-3-quarters"; "cloud-upload-o"; "cloud-download-o"; "cloud-upload"; "cloud-o"; "star-o"; "star"; "heart-o"; "heart"; "environment"; "environment-o"; "eye"; "eye-o"; "camera"; "camera-o"; "save"; "team"; "solution"; "phone"; "filter"; "exception"; "export"; "customer-service"; "qrcode"; "scan"; "like"; "like-o"; "dislike"; "dislike-o"; "message"; "pay-circle"; "pay-circle-o"; "calculator"; "pushpin"; "pushpin-o"; "bulb"; "select"; "switcher"; "rocket"; "bell"; "disconnect"; "database"; "compass"; "barcode"; "hourglass"; "key"; "flag"; "layout"; "printer"; "sound"; "usb"; "skin"; "tool"; "sync"; "wifi"; "car"; "schedule"; "user-add"; "user-delete"; "usergroup-add"; "usergroup-delete"; "man"; "woman"; "shop"; "gift"; "idcard"; "medicine-box"; "red-envelope"; "coffee"; "copyright"; "trademark"; "safety"; "wallet"; "bank"; "trophy"; "contacts"; "global"; "shake"; "api"; "fork"; "dashboard"; "form"; "table"; "profile"]

    let renderItem s = 
      List.item [  ] [ 
         Card.card [ Style [TextAlign "center"]; Card.Bordered false] [
                Icon.icon [ Style [FontSize 24]; Icon.Type s; Icon.Title s] []
                div [] [str s]
            ]
         ]

    let renderIconList icons title= 
      div [ Style [Clear "both"] ] [ 
        h3 [] [str title]
        List.list [ List.Grid {
                gutter = Some 16
                column = None
                xs = Some List.One
                sm = Some List.Two
                md = Some List.Four
                lg = Some List.Four
                xl = Some List.Six
                xxl = Some List.Six};
              ] [ for ico in icons ->
                    renderItem ico
                ]
      ]

    let root model dispatch =

      div [ ] [

              DemoCard.View.root 
                { title = "Icon demo"; 
                  demo = General.Icons.IconDemo.view ; 
                  source = importAll "!!highlight-loader?raw=true&lang=fsharp!./_IconDemo.fs"; 
                  activeTab = model 
                }  (ChangeTabMsg >> dispatch  ) 

              h1 [] [str "List of icons"] 
              renderIconList direction "Directional Icons"
              renderIconList suggestion "Suggested Icons"
              renderIconList application "Application Icons"
              renderIconList logo "Brand and Logos"
            ]
