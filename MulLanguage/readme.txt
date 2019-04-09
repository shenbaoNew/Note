//改实例演示了Winform多语言切片的场景
1：新建一个英文的资源文件（和普通的中文资源文件有以下的区别）
<resheader name="resmimetype">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name="version">
    <value>2.0</value>
  </resheader>
  <resheader name="reader">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name="writer">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name="button1.Text" xml:space="preserve">
    <value>OK</value>
  </data>
  <data name="label1.Text" xml:space="preserve">
    <value>User Name</value>
  </data>
  <assembly alias="System.Windows.Forms" name="System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
  <data name="$this.ImeMode" type="System.Windows.Forms.ImeMode, System.Windows.Forms">
    <value>Inherit</value>
  </data>
  2：初始化线程语言别
    CultureInfo newCultureInfo = new CultureInfo(GetCultureInfoName(threeLetterLanguageName));
    if (Thread.CurrentThread.CurrentUICulture.LCID != newCultureInfo.LCID) {
        Thread.CurrentThread.CurrentUICulture = newCultureInfo;
        ComponentResourceManager resources = new ComponentResourceManager(typeof(IPAddress));

        resources.ApplyResources(button1, button1.Name);
        resources.ApplyResources(label1, label1.Name);
        resources.ApplyResources(this, "$this");
    }