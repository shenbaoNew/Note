安装命令：npm install -g @angular/cli

如果安装不成功则：
// 1.验证缓存数据的有效性和完整性，清理垃圾数据。
npm cache verify

// 2.删除缓存目录下的所有数据。(在npm5的版本之后，需要加上--force来保证缓存数据的有效性和完整性。
npm cache clean

// 3.强制清理
npm cache clean --force

// 4.删除文件夹
C:\Users\shenbao.DIGIWIN.000\AppData\Roaming\npm\node_modules\@angular

再执行安装命令
npm install -g @angular/cli