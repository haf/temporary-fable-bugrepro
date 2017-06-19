module VATComponents.View

open Types
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers
open Fable.Helpers.React
open Fable.Helpers.React.Props

let checkbox (model: Model) dispatch =
  div
    [ ClassName "checkbox-component"]
    [ str "Multi"
      input
        [ Type "checkbox"
          Style
            [ CSSProp.Float "right"
              CSSProp.Width "20px"
              CSSProp.Height "20px"
            ]
          OnChange (fun _ -> dispatch (SetMultiTaxes (not model.isMulti)))
        ]
    ]
let rateSubcomponents model dispatch =
  div
    []
    [
      dd
        []
        [ str "25%"]
      dt
        []
        [ input [] ]
      dd
        []
        [ str "12%"]
      dt
        []
        [ input [] ]
      dd
        []
        [ str "6%"]
      dt
        []
        [ input [] ]
      dd
        []
        [ str "Total tax free"]
      dt
        []
        [ input [ ] ]
      dd
        []
        [ str "Untaxed amount"]
      dt
        []
        [ str "TODO" ]
    ]

type StatefulComponent<'P, 'S>(factory: unit -> 'S, dispose: 'S -> unit, props, compnent) =
  inherit React.Component<'P, 'S>(props)

  member x.render () =
    from compnent props []

  interface React.ComponentLifecycle<'P, 'S> with
    override x.componentDidMount () =
      x.setState (factory ())

    override x.componentWillUnmount () =
      dispose x.state

let withDispose factory dispose =
  component <| fun props innerComponent ->
    StatefulComponent (factory, dispose, props, innerComponent)
    :> React.ReactElement

let typedField tryParse tryValidate onValue: React.ReactElement =

  div
    []
    [
      input
        [ OnChange  ]


    ]

let root (model: Model) dispatch =
  div
    [ ClassName "content" ]
    [ h1
        [ ]
        [ str "Taxes"
          checkbox model dispatch
        ]
      dl
        [ ]
        [
          yield dd
            []
            [ str "Total taxes" ]
          yield dt
            []
            [ input
                [ OnChange (fun e -> dispatch (SetTotalTax (e.target?value))) ]
            ]
          if Option.fold (fun s t -> t) 0. model.totalTaxes > 0. then
            yield rateSubcomponents model dispatch
          else
            ()
        ] ]