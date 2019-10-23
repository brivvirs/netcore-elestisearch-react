import React from "react";
import AppBar from "@material-ui/core/AppBar";
import Tabs from "@material-ui/core/Tabs";
import Tab from "@material-ui/core/Tab";
import { ChangeSection } from "../../store/actions";
import { connect } from "react-redux";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import { AddNewSection } from "../../services/autocomplete.service";

class AutoCompleteSections extends React.Component {


  onSectionChange(index, section) {
    this.props.ChangeSection(index, section);
  }

  handleChange(input) {
    const val = input.target.value;
    this.setState({ sectionTitle: val });
    console.log(input);
  }


  async onNewTitleSubmit() {
    const title = this.state.sectionTitle;
    this.setState({ sectionTitle: "" });
    await AddNewSection(title);
  }

  render() {
    const selectedIndex = !!this.props.selectedSection
      ? this.props.selectedSection.index
      : 0;
    const inputValue =
      !!this.state && !!this.state.sectionTitle ? this.state.sectionTitle : "";
    return (
      <div>
        <AppBar position="static">
          <Tabs value={selectedIndex}>
            {this.props.sections &&
              this.props.sections.map((section, index) => {
                return (
                  <Tab
                    key={index}
                    label={section.title}
                    onClick={() => this.onSectionChange(index, section)}
                  />
                );
              })}
          </Tabs>
          <div id="modalSectionTitle">
            <TextField
              id="standard-name"
              label="Title"
              value={inputValue}
              onChange={e => this.handleChange(e)}
              margin="normal"
              variant="outlined"
            />
            <Button onClick={() => this.onNewTitleSubmit()} variant="contained">
              Add
            </Button>
          </div>
        </AppBar>
      </div>
    );
  }
}

const mapStateToProps = (section, state) => {
  if (!!section && !!section.section) {
    return { selectedSection: section.section };
  } else return state;
};

export default connect(
  mapStateToProps,
  { ChangeSection }
)(AutoCompleteSections);
