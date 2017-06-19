module App.Types

open Global

type Msg =
  | CounterMsg of Counter.Types.Msg
  | HomeMsg of Home.Types.Msg
  | VATComponentsMsg of VATComponents.Types.Msg

type Model =
  { currentPage: Page
    counter: Counter.Types.Model
    vatComponents: VATComponents.Types.Model
    home: Home.Types.Model }
