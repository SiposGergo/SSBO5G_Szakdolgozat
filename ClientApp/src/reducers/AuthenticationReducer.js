let user = JSON.parse(localStorage.getItem('user'));
const initialState = user ? { loggedIn: true, user } : {};

export const authentication = (state = initialState, action) => {
  switch (action.type) {
    case 'USERS_LOGIN_REQUEST':
      return {
        loggingIn: true
      };

    case 'USERS_LOGIN_SUCCESS':
      return {
        loggedIn: true,
        user: action.user
      };

    case 'USERS_LOGIN_FAILURE':
      return {
        loggedIn: false
      };

    case 'USERS_LOGOUT':
      return {
        loggedIn: false,
        user: null
      };

    case "USER_UPDATE_SUCCESS":
      return {
        loggedIn: true,
        user : action.user
      };

    default:
      return state
  }
}