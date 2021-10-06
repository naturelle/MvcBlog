var Hello = React.createClass({
    render: function () {
        return (
            <div>Hello this is a react page</div>
        )
    }
});

React.render(<Hello />, document.getElementById("reactdiv"));