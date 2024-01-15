import React from 'react';
import './components.css'

class AddPersonForm extends React.Component {
    render = () => {
        return (
            <form>
                <table>
                    <tr>
                        <td className="label_content">
                            <label placeholder="firstName">First name</label>
                        </td>
                        <td className="input_content">
                            <input></input>
                        </td>
                    </tr>
                    <tr>
                        <td className="label_content">
                            <label>Last name</label>
                        </td>
                        <td className="input_content">
                            <input pleaceholde="lastName"></input>
                        </td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td className="content_buttons">
                            <button>Cancel</button>
                            <button type="submit">OK</button>
                        </td>
                    </tr>
                </table>                
            </form>
        );
    }
}

export default AddPersonForm;