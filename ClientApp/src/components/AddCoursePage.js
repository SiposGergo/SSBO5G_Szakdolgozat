import React from "react";
import { connect } from "react-redux";
import CourseForm from "./forms/CourseForm/CourseForm";
import { AddCourseToHike } from "../actions/AddHikeCourseActions";
import { getHikeDetails, deleteData } from '../actions/EditHikeActions';

class AddCoursePage extends React.Component {

    componentWillMount() {
        this.props.dispatch(getHikeDetails(this.props.match.params.id));
    }

    componentWillUnmount() {
        this.props.dispatch(deleteData());
    }

    onSubmit = (values) => {
        console.log(values);
        this.props.dispatch(AddCourseToHike(values, this.props.match.params.id));
    }

    render() {
        if (this.props.hasErrored) {
            return (<div>Nincs ilyen túra!</div>);
        }

        if (this.props.hike.organizer && this.props.hike.organizer.id != this.props.user.id) {
            return (<div>Csak a saját szervezésű túrádhoz tudsz távot hozzáadni!</div>)
        }
        else {
            return (
                <div>
                    <CourseForm
                        onSubmit={this.onSubmit}
                        title="Új táv hozzáadása!"
                        baseDate={this.props.hike.date} />
                </div>)
        }
    }
}

const mapStateToProps = (state) => {
    return {
        hike: state.hikeEditReducer.hike,
        hasErrored: state.hikeEditReducer.hasErrored,
        user: state.authentication.user
    }
}

export default connect(mapStateToProps, null, null, {pure:false})(AddCoursePage);