پیاده سازی یک رستوران که قابلیت مدیریت سفارش و پیگیری سفارش و همچنین دارای پنل ادمین است و Role های متفاوتی را دارد وهمچنین دارای Api است . در این پروژه از سیستم احراز هویت کاستوم استفاده شده است که به صورت bounded-context است و قابلیت جدا شدن و انتقال آن به یک پروژه دیگر را دارد  از دیتابیس Sql Server و از الگوی Unit Of Work و Generic Repository برای مدیریت دیتابیس استفاده شده است. در این پروژه از درگاه پرداخت Strip استفاده شده است. در این پروژه از معماری onion استفاده شده است و سولوشن پروژه براساس یک تمپلیت ساخته شده تا مدیریت پروژه راحت تر باشد همچنین سعی شده که مفایهم Clean Code به درستی در این پروژه استفاده شود.در این پروژه جلوی حملات Xss و Csrf و  Local Redirect گرفته شده اس و همچنین برای امنیت بیشتر یک میدل ویر اختصاصی ساخته شده تا مک آدرس سیستم هر رکوئستی که وارد میشود را برسی و چک کند و همچنین از اکشن فیلتر ها هم استفاده شده و دارای صفحه های ارور 404 و  Access Denied . تکنولوژی های استفاده شده :
Asp.net Core Razor Page
Asp.net core Web Api
Sql server
EfCore
Ioc
Html css
Java scrtipt
Jquery
SweetAlert
Bootstrap 
Onion Architecture
