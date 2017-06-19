module Global

type Page =
  | Home
  | Counter
  | VATComponents
  | About

let toHash page =
  match page with
  | About -> "#about"
  | Counter -> "#counter"
  | VATComponents -> "#vatcomponents"
  | Home -> "#home"
