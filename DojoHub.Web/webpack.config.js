const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const autoprefixer = require('autoprefixer');
const webpack = require('webpack');

module.exports = {
    mode: 'none',
    entry: {
        main: ['./scripts/bundle.js',
            './scss/main.scss'
        ],
        vendor: ['./scripts/application.js'
        ]
    },
    externals: {
        jquery: 'jQuery',
        lazysizes: 'lazySizes'
    },
    devtool: "inline-eval-cheap-source-map",
    output: {
        path: path.join(__dirname, "scripts/build"),
        filename: "[name].bundle.js",
        publicPath: 'http://localhost:9000/'
    },
    resolve: {
        modules: ["node_modules"]
    },
    devServer: {
        hot: true,
        contentBase: [path.join(__dirname, "scripts/build"), path.join(__dirname, "/")],
        compress: true,
        publicPath: 'http://localhost:9000/',
        port: 9000,
        headers: {
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "GET, POST, PUT, DELETE, PATCH, OPTIONS",
            "Access-Control-Allow-Headers": "X-Requested-With, content-type, Authorization"
        }
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: "[name].css",
            chunkFilename: "[id].css"
        }),
        new webpack.HotModuleReplacementPlugin()
    ],
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [
                    'css-hot-loader',
                    MiniCssExtractPlugin.loader,
                    {
                        loader: "css-loader",
                        options: {
                            url: false,
                            minimize: {
                                sourceMap: true
                            }
                        }
                    },
                    {
                        loader: "postcss-loader",
                        options: {
                            autoprefixer: {
                                browsers: ['last 2 version', 'safari >= 9']
                            },
                            plugins: () => [autoprefixer]
                        }
                    },
                    {
                        loader: "sass-loader",
                        options: {
                            sourceMap: true
                        }
                    }
            ]
    }, {
    test: /\.js$/,
        exclude: /(node_modules|bower_components)/,
        use: {
        loader: "babel-loader",
            options: {
            presets: ["env"]
        }
    }
}]
}
};