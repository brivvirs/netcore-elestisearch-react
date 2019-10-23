import React from "react";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemText from "@material-ui/core/ListItemText";
import { connect } from "react-redux";

class Suggestion extends React.Component {
  render() {
    return (
      <div>
        <List>
          {this.props.hints &&
            this.props.hints.map(x => (
              <ListItem button key={x.id}>
                <ListItemText>{x.word}</ListItemText>
              </ListItem>
            ))}
        </List>
      </div>
    );
  }
}

const mapStateToProps = (action, state) => {
  return { ...action };
};

export default connect(
  mapStateToProps,
  null
)(Suggestion);
