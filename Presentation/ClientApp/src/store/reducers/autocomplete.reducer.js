import {
  ADDHINTWORD,
  CHANGEMASTERWORD,
  ADDSECTION,
  CHANGESECTION,
  DELETESECTION,
  HINTUPDATE
} from "../actiontype";

const AutoCompleteReducer = (state, action) => {
  switch (action.type) {
    case ADDHINTWORD: {
      return state;
    }
    case CHANGEMASTERWORD: {
      return { ...state, word: action.payload };
    }
    case HINTUPDATE: {
      return { ...state, hints: action.payload };
    }
    case ADDSECTION: {
      return state;
    }
    case CHANGESECTION: {
      return { ...state, section: action.payload };
    }
    case DELETESECTION: {
      return state;
    }
    default: {
      return state;
    }
  }
};

export default AutoCompleteReducer;
