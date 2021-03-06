const path = require("path");
const ExtractTextPlugin = require('extract-text-webpack-plugin');

const CSSExtract = new ExtractTextPlugin("styles.css");

module.exports = (env) => {
    console.log("env: ",env);
    const isProduction = env === "production";
    return {
        entry: "./src/app.js",
        output: {
            path: path.join(__dirname, "public", "dist"),
            filename: "bundle.js"
        },
        module: {
            rules: [{
                loader: 'babel-loader',
                test: /\.js$/,
                exclude: /node_modules/
            }, {
                test: /\.s?css$/,
                use: CSSExtract.extract({
                    use: [
                        {
                            loader: "css-loader",
                            options: {
                                sourceMap: true,
                            }
                        },
                        {
                            loader: "sass-loader",
                            options: {
                                sourceMap: true
                            }
                        }
                    ]
                })
            },
            {
                test: /\.(png|woff|woff2|eot|ttf|svg)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: { publicPath: "/dist/" }
                    }
                ]
            }]
        },
        plugins: [
            CSSExtract
        ],
        devtool: isProduction ? 'source-map': "cheap-module-eval-source-map",
        devServer: {
            contentBase: path.join(__dirname, "public"),
            historyApiFallback: true,
            publicPath: "/dist/"
        },

    }
};