#include <monotouch/monotouch.h>
#include <objc/objc.h>
#include <objc/runtime.h>

#if defined (__arm__)
void __attribute__ ((constructor)) monotouch_create_classes (void);

static MTClassMap __monotouch_class_map [] = {
	{"NSObject", "MonoTouch.Foundation.NSObject, monotouch", 0},
	{"NSString", "MonoTouch.Foundation.NSString, monotouch", 0},
	{"NSUserDefaults", "MonoTouch.Foundation.NSUserDefaults, monotouch", 0},
	{"NSArray", "MonoTouch.Foundation.NSArray, monotouch", 0},
	{"NSDictionary", "MonoTouch.Foundation.NSDictionary, monotouch", 0},
	{"NSIndexPath", "MonoTouch.Foundation.NSIndexPath, monotouch", 0},
	{"NSException", "MonoTouch.Foundation.NSException, monotouch", 0},
	{"UIBarItem", "MonoTouch.UIKit.UIBarItem, monotouch", 0},
	{"UIResponder", "MonoTouch.UIKit.UIResponder, monotouch", 0},
	{"UIImage", "MonoTouch.UIKit.UIImage, monotouch", 0},
	{"MonoTouch.UIKit.UIControlEventProxy", "MonoTouch.UIKit.UIControlEventProxy, monotouch", 0},
	{"__UIGestureRecognizerToken", "MonoTouch.UIKit.UIGestureRecognizer+Token, monotouch", 0},
	{"UIFont", "MonoTouch.UIKit.UIFont, monotouch", 0},
	{"UIGestureRecognizer", "MonoTouch.UIKit.UIGestureRecognizer, monotouch", 0},
	{"UIColor", "MonoTouch.UIKit.UIColor, monotouch", 0},
	{"__MonoTouch_Disposer", "MonoTouch.Foundation.NSObject+MonoTouch_Disposer, monotouch", 0},
	{"UITabBarItem", "MonoTouch.UIKit.UITabBarItem, monotouch", 0},
	{"AppDelegate", "TheGym.AppDelegate, TheGym", 0},
	{"UIApplication", "MonoTouch.UIKit.UIApplication, monotouch", 0},
	{"TheGym.ScheduleTableViewDataSource", "TheGym.ScheduleTableViewDataSource, TheGym", 0},
	{"UIViewController", "MonoTouch.UIKit.UIViewController, monotouch", 0},
	{"UIView", "MonoTouch.UIKit.UIView, monotouch", 0},
	{"TheGym.GymsTableViewDataSource", "TheGym.GymsTableViewDataSource, TheGym", 0},
	{"TheGym.GymTabBarControllerDelegate", "TheGym.GymTabBarControllerDelegate, TheGym", 0},
	{"TheGym.ScheduleViewController", "TheGym.ScheduleViewController, TheGym", 0},
	{"UIAlertView", "MonoTouch.UIKit.UIAlertView, monotouch", 0},
	{"TheGym.BookingViewController", "TheGym.BookingViewController, TheGym", 0},
	{"TheGym.ScheduleTableViewDelegate", "TheGym.ScheduleTableViewDelegate, TheGym", 0},
	{"TheGym.GymSettingsViewController", "TheGym.GymSettingsViewController, TheGym", 0},
	{"UITableViewCell", "MonoTouch.UIKit.UITableViewCell, monotouch", 0},
	{"UIControl", "MonoTouch.UIKit.UIControl, monotouch", 0},
	{"TheGym.GymsTableViewDelegate", "TheGym.GymsTableViewDelegate, TheGym", 0},
	{"UIWindow", "MonoTouch.UIKit.UIWindow, monotouch", 0},
	{"UILabel", "MonoTouch.UIKit.UILabel, monotouch", 0},
	{"UITabBarController", "MonoTouch.UIKit.UITabBarController, monotouch", 0},
	{"UITableViewController", "MonoTouch.UIKit.UITableViewController, monotouch", 0},
	{"UIScrollView", "MonoTouch.UIKit.UIScrollView, monotouch", 0},
	{"UINavigationController", "MonoTouch.UIKit.UINavigationController, monotouch", 0},
	{"TheGym.GymsTableViewController", "TheGym.GymsTableViewController, TheGym", 0},
	{"UIButton", "MonoTouch.UIKit.UIButton, monotouch", 0},
	{"UITextField", "MonoTouch.UIKit.UITextField, monotouch", 0},
	{"UITableView", "MonoTouch.UIKit.UITableView, monotouch", 0},
	{"TheGym.GymTabBarController", "TheGym.GymTabBarController, TheGym", 0},
	{"TheGym.ScheduleTableViewController", "TheGym.ScheduleTableViewController, TheGym", 0},
	{"TheGym.GymClassTableViewCell", "TheGym.GymClassTableViewCell, TheGym", 0},
};

static MTClass __monotouch_classes [] = {
	{"AppDelegate", "NSObject", 2, 6},
	{"TheGym.ScheduleTableViewDataSource", "NSObject", 1, 4},
	{"TheGym.GymsTableViewDataSource", "NSObject", 1, 5},
	{"TheGym.GymTabBarControllerDelegate", "NSObject", 1, 3},
	{"TheGym.ScheduleViewController", "UIViewController", 1, 4},
	{"TheGym.BookingViewController", "UIViewController", 1, 3},
	{"TheGym.ScheduleTableViewDelegate", "NSObject", 1, 3},
	{"TheGym.GymSettingsViewController", "UIViewController", 1, 5},
	{"TheGym.GymsTableViewDelegate", "NSObject", 1, 5},
	{"TheGym.GymsTableViewController", "UITableViewController", 1, 4},
	{"TheGym.GymTabBarController", "UITabBarController", 1, 4},
	{"TheGym.ScheduleTableViewController", "UITableViewController", 1, 5},
	{"TheGym.GymClassTableViewCell", "UITableViewCell", 1, 2},
};

static MTIvar __monotouch_ivars [] = {
	{"__monoObjectGCHandle", "i", 4, 4},
	{"window", "@", 4, 2},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
	{"__monoObjectGCHandle", "i", 4, 4},
};

static MTMethod __monotouch_methods [] = {
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"init","@@:",0, &monotouch_ctor_trampoline},
	{"application:didFinishLaunchingWithOptions:","B@:@@",0, &monotouch_trampoline},
	{"applicationWillEnterForeground:","v@:@",0, &monotouch_trampoline},
	{"applicationDidBecomeActive:","v@:@",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"tableView:numberOfRowsInSection:","i@:@i",0, &monotouch_trampoline},
	{"tableView:cellForRowAtIndexPath:","@@:@@",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"init","@@:",0, &monotouch_ctor_trampoline},
	{"tableView:cellForRowAtIndexPath:","@@:@@",0, &monotouch_trampoline},
	{"tableView:numberOfRowsInSection:","i@:@i",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"init","@@:",0, &monotouch_ctor_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"viewDidLoad","v@:",0, &monotouch_trampoline},
	{"viewWillAppear:","v@:B",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"viewDidLoad","v@:",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"tableView:didSelectRowAtIndexPath:","v@:@@",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"init","@@:",0, &monotouch_ctor_trampoline},
	{"viewDidLoad","v@:",0, &monotouch_trampoline},
	{"viewWillDisappear:","v@:B",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"init","@@:",0, &monotouch_ctor_trampoline},
	{"tableView:didSelectRowAtIndexPath:","v@:@@",0, &monotouch_trampoline},
	{"tableView:heightForRowAtIndexPath:","f@:@@",0, &monotouch_fpret_single_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"init","@@:",0, &monotouch_ctor_trampoline},
	{"viewDidLoad","v@:",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"init","@@:",0, &monotouch_ctor_trampoline},
	{"viewDidLoad","v@:",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
	{"viewDidLoad","v@:",0, &monotouch_trampoline},
	{"viewDidAppear:","v@:B",0, &monotouch_trampoline},
	{"viewWillAppear:","v@:B",0, &monotouch_trampoline},
	{"release","v@:",0, &monotouch_release_trampoline},
	{"retain","@@:",0, &monotouch_retain_trampoline},
};

int __monotouch_map_count = 45;
static int __monotouch_class_count = 13;

void monotouch_create_classes (void) {
#if defined (DEBUG_LAUNCH_TIME)
	NSAutoreleasePool *pool = [NSAutoreleasePool new];
	NSDate *date = [NSDate date];
#endif
	int i,j;
	int ivar_offset = 0;
	int method_offset = 0;

	for (i = 0; i < __monotouch_class_count; i++) {
		Class handle = objc_allocateClassPair (objc_getClass (__monotouch_classes [i].supername), __monotouch_classes [i].name, 0);
		if (handle == NULL) {
			ivar_offset += __monotouch_classes [i].ivar_count;
			method_offset += __monotouch_classes [i].method_count;
			continue;
		}
		for (j = 0; j < __monotouch_classes [i].ivar_count; j++, ivar_offset++)
			class_addIvar (handle, __monotouch_ivars [ivar_offset].name, __monotouch_ivars [ivar_offset].size, __monotouch_ivars [ivar_offset].align, __monotouch_ivars [ivar_offset].type);
		for (j = 0; j < __monotouch_classes [i].method_count; j++, method_offset++) {
			Class h = (__monotouch_methods [method_offset].isstatic ? handle->isa : handle);
			class_addMethod (h, sel_registerName (__monotouch_methods [method_offset].selector), __monotouch_methods [method_offset].trampoline, __monotouch_methods [method_offset].signature);
		}
		objc_registerClassPair (handle);
	}
	for (i = 0; i < __monotouch_map_count; i++) {
		__monotouch_class_map [i].handle = objc_getClass (__monotouch_class_map [i].name);
	}
	monotouch_setup_classmap (__monotouch_class_map, __monotouch_map_count);
#if defined (DEBUG_LAUNCH_TIME)
	NSLog([NSString stringWithFormat:@"Registrar time: %fs", -[date timeIntervalSinceNow]]);
	[date autorelease];
#endif
}
#endif
