import {
  ADDHINTWORD,
  CHANGESECTION,
  DELETESECTION,
  ADDSECTION,
  CHANGEMASTERWORD,
  HINTUPDATE
} from "./actiontype";
import { GetHintWords } from "../services/autocomplete.service";

export const AddSection = title => {
  return {
    type: ADDSECTION,
    payload: title
  };
};

export const AddHintWord = word => {
  return {
    type: ADDHINTWORD,
    payload: word
  };
};

export const HintUpdate = words => {
  return {
    type: HINTUPDATE,
    payload: words
  };
};

export const ChangeSection = (index, section) => {
  return {
    type: CHANGESECTION,
    payload: {
      index: index,
      section: section
    }
  };
};

export const DeleteSection = section => {
  return {
    type: DELETESECTION,
    payload: section
  };
};

export const ChangeMasterWord = currentWord => {
  return {
    type: CHANGEMASTERWORD,
    payload: currentWord
  };
};

export const ChangeMasterWordUpdateHintAsync = (sectionId, currentWord) => {
  return dispatch => {
    GetHintWords(sectionId,currentWord).then(result => {
      dispatch(HintUpdate(result));
    });
  };
};
