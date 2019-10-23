import React from "react";
import TextField from "@material-ui/core/TextField";
import {
  ChangeMasterWord,
  ChangeMasterWordUpdateHintAsync
} from "../../store/actions";
import { connect } from "react-redux";

const handleChange = (props, input) => {
  props.ChangeMasterWord(input);
  const sectionId = props.section.section.id;
  props.ChangeMasterWordUpdateHintAsync(sectionId,input);
};

const AutoCompleteInput = props => {
  return (
    <div>
      <TextField
        id="standard-name"
        label="Name"
        onChange={input => handleChange(props, input.target.value)}
        margin="normal"
      />
    </div>
  );
};

const mapStateToProps = state => {
  return { ...state };
};

export default connect(
  mapStateToProps,
  { ChangeMasterWord, ChangeMasterWordUpdateHintAsync }
)(AutoCompleteInput);
