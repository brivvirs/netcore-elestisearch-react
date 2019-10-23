import { createStore, applyMiddleware } from "redux";
import AutoCompleteReducer from "./reducers/autocomplete.reducer";
import thunk from "redux-thunk";

export default createStore(
  AutoCompleteReducer,
  applyMiddleware(thunk)
);
