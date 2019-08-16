1. 安装
```
npm i -S react-app-rewired@2.0.2-next.0 babel-plugin-import 
```
2. 添加名为config-overrides.js的配置文件 
内容如下
```
const { injectBabelPlugin } = require('react-app-rewired');
module.exports = function override(config, env) {
    config = injectBabelPlugin(['import', { libraryName: 'antd', libraryDirectory: 'es', style: 'css' }], config);
    return config;
}
```

3.package.json react-scripts 换为reaact-app-rewired