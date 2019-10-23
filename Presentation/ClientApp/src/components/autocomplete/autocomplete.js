import React from "react";
import AutoCompleteInput from "./inputfield";
import Suggestion from "./suggestion";
import AutoCompleteSections from "./sectionselector";
import Container from "@material-ui/core/Container";
import { GetSections } from "../../services/autocomplete.service";
import { ChangeSection } from "../../store/actions";
import axios from "axios";
import { connect } from "react-redux";

class AutoComplete extends React.Component {
  componentWillMount = async () => {
    const result = await GetSections();
    if (!result.length) {
      axios.get(`hints/init`).then(res => {
        window.location = "";
      });
    } else {
      this.props.ChangeSection(0, result[0]);
    }
    this.setState({
      sections: result
    });
  };

  renderLoading() {
    return <h3>Loading initial data...</h3>;
  }

  renderBody() {
    return (
      <div>
        <AutoCompleteSections
          sections={this.state && this.state.sections}
        ></AutoCompleteSections>
        <Container maxWidth="sm">
          <AutoCompleteInput></AutoCompleteInput>
          <Suggestion></Suggestion>
        </Container>
      </div>
    );
  }

  render() {
    if (this.state && this.state.sections && this.state.sections.length == 0) {
      return this.renderLoading();
    } else {
      return this.renderBody();
    }
  }
}

export default connect(
  null,
  { ChangeSection }
)(AutoComplete);
