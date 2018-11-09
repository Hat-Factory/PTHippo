using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pt_Hippo_Mobile.Model.Regusteratin_LogIn_model;
using System.Collections.ObjectModel;
using Pt_Hippo_Mobile.Model;
using Pt_Hippo_Mobile.Model.licensesModel;
using Pt_Hippo_Mobile.Enums;

namespace Pt_Hippo_Mobile.Helpers
{
   public  class constants
    {
        public static int currentDayOfWeek;
        public static string Message;
        public static List<RatinganswerModel> mysubmits = null;
        public const string serverUrl = "http://www.pthippo.com/";
        //public const string serverUrl = "http://52.151.35.167/";

        public const string uploadsURl = serverUrl+"uploads/";
        public static bool gendder;
        public static ObservableCollection<EmployeeSchedule> senddata = new ObservableCollection<EmployeeSchedule>();
        public static ObservableCollection<EmployeeSchedule> datas = new ObservableCollection<EmployeeSchedule>();
        public static ObservableCollection<jobtimesheetmodel> jobtime = new ObservableCollection<jobtimesheetmodel>();
        public static ObservableCollection<licensesModel> licencesitem = new ObservableCollection<licensesModel>();
        public static ObservableCollection<LicencesDocumentModel> backgroundchecklist = new ObservableCollection<LicencesDocumentModel>();
        //TODO : Working Here to change the default value to be Null 
        public static DocumentType CurrentDocumentType = DocumentType.initial;
        public static ObservableCollection<Resume> expirenceitem = new ObservableCollection<Resume>();
        public static BankAccount banckaccountinfo = new BankAccount();
        public static int PendingRatingCount;
        public static bool IsSignUp;
        public static string reporttitle ;
        public static string placeholder;
        public static bool AgreedOnTOSAndPrivacy;
        public static bool SearchView;

        /*public static string termsofused = @"These terms and conditions of use (“Terms of Use”) govern your use of the Platform and
application owned and operated by PT Hippo, INC (“PT Hippo”), which Platform is located at
www.PTHippo.com (the “Website” or the “Site”) and all related sub-domains, mobile versions,
tools, and services or through downloadable application (collectively, the “Platform”). The PT
Hippo Platform connects medical service providers (each a “Provider”, and collectively, “Providers”)
seeking of temporary and/or replacement practitioners with third party individuals (each a “Candidate”
and collectively, “Candidates”) who render physical therapy services (the “Services”). Providers and
Candidates together are collectively referred to as “Users”";*/
        
        public static string termsofused1 =@"These terms and conditions of use (“Terms of Use”) govern your use of the Platform and
application owned and operated by PT Hippo, INC (“PT Hippo”), which Platform is located at
www.PTHippo.com (the “Website” or the “Site”) and all related sub-domains, mobile versions,
tools, and services or through downloadable application (collectively, the “Platform”). The PT
Hippo Platform connects medical service providers (each a “Provider”, and collectively, “Providers”)
seeking of temporary and/or replacement practitioners with third party individuals (each a “Candidate”
and collectively, “Candidates”) who render physical therapy services (the “Services”). Providers and
Candidates together are collectively referred to as “Users” and each individually as a “User,”,
and referred to herein as User or “You” or “Your”. If you do not agree to be bound by the Terms of
Use, promptly exit this site. PT Hippo reserves the right to update or modify these Terms of Use at
any time by providing notice on the Platform, and Your use of this Platform following any such
change constitutes Your agreement to the revised Terms of Use from and after that date. These
Terms of Use incorporate by reference our Privacy Policy as referenced in the Platform from
time to time.
PLEASE READ THESE TERMS OF USE CAREFULLY, AS THEY CREATE A
BINDING CONTRACT BETWEEN YOU AND PT HIPPO.
1. PT HIPPO Marketplace. The PT Hippo Platform serves as a marketplace to connect
Providers and Candidates for Services. Each User by agreeing to this Terms of Use
through use of the Services is authorized to create a profile on the Website to market to
other Users and find connections, subject to the terms and conditions set forth herein.
2. User Account. Users may share information through the Platform, including Fees
(defined below), skill set, availability, proximity and Ratings (defined below).
YOU ARE SOLELY RESPONSIBLE FOR INFORMATION POSTED TO OR
PROVIDED ON YOUR ACCOUNT, AND FOR YOUR INTERACTIONS WITH
OTHER USERS. YOU UNDERSTAND THAT PT HIPPO DOES NOT CONDUCT
CRIMINAL BACKGROUND CHECKS OR SCREENINGS ON ITS USERS, NOR
DOES PT HIPPO CHECK OR CONFIRM ANY INFORMATION POSTED BY
ANY USER. PT HIPPO ALSO DOES NOT INQUIRE INTO THE
BACKGROUNDS OF ITS USERS OR ATTEMPT TO VERIFY THE
STATEMENTS OF ITS USERS. PT HIPPO MAKES NO REPRESENTATIONS
OR WARRANTIES AS TO THE CONDUCT OF USERS OR THEIR ACTIONS
WITH ANY CURRENT OR FUTURE USERS. PT HIPPO RESERVES THE
RIGHT TO CONDUCT ANY CRIMINAL BACKGROUND CHECK OR OTHER
SCREENINGS AT ANY TIME AND USING AVAILABLE PUBLIC RECORDS.
PT Hippo is not responsible for the conduct of any User. In no event shall PT Hippo,
its affiliates or its partners be liable (directly or indirectly) for any losses or damages
whatsoever, whether direct, indirect, general, special, compensatory, consequential,
and/or incidental, arising out of or relating to the conduct of you or anyone else in
connection with the use of the Services including, without limitation, death, bodily
injury, emotional distress, and/or any other damages resulting from 
communications or meetings with other Users or persons. You agree to take all
necessary precautions in all interactions with other Users, particularly if you decide to
communicate in person.
You are responsible for maintaining the confidentiality of the username and password
you designate during the registration process, and you are solely responsible for all
activities that occur under your username and password. You agree to immediately notify
PT Hippo of any disclosure or unauthorized use of your username or password or any
other breach of security, and ensure that you log out from your account at the end of each
session.
PT Hippo is a marketplace for Providers and Candidates to connect. PT Hippo does not
employ or retain Candidates and PT Hippo does not provide Candidate services to
Providers other than the marketplace Services set forth herein. The Provider is the party
that contracts with the Candidate to complete certain services over a period of time
(“Assignment”), which may be scheduled through the Platform. PT Hippo provides a
platform for making introductions and placement for Assignments between Providers and
Candidates. PT Hippo has no liability to any User with regard to the quality of the
Candidates or whether any Provider offers suitable Assignments for any Candidate.
Using the Platform, Candidate may request information on the average hourly rate for the
Assignments that Candidate is offering, based on characteristics of Assignments as
determined by PT Hippo from time to time. Likewise, Provider may request information
on the average hourly rate for the Assignments that Provider requesting, based on
characteristics of Assignments as determined by PT Hippo from time to time. ANY
INFORMATION ON AVERAGE HOUR RATES FROM PT HIPPO IS PROVIDED
“AS IS” AND WITHOUT WARRANTIES OF ANY KIND AND PT HIPPO
DISCLAIMS ALL WARRANTIES, INCLUDING WITHOUT LIMITATION
NONINFRINGEMENT, FITNESS FOR A PARTICULAR PURPOSE,
MERCHANTABILITY AND ACCURACY.
3. Fees. Provider may submit a request for particular Assignment to PT Hippo, free of
charge, through the Platform together with a range of hourly rates that are acceptable to
the Provider (“Request for Assignment” or “Request”). When PT Hippo receives such a
Request from a Provider, PT Hippo’s algorithm connects Provider with Candidates
meeting criteria specified. Access to each Users’ Ratings and Profile is free of charge.
For each Assignment, PT Hippo bills Provider through an online account ('Billing
Account'). Provider agrees to pay to PT Hippo all charges for each Assignment at least
twenty four (24) hours prior to the commencement of the Assignment using the Billing
Account. PT Hippo reserves the right to correct any billing errors or mistakes that it
makes even if it has already requested or received payment. If Provider initiates a
chargeback or otherwise reverses any payment previously received, PT Hippo may in its
discretion terminate Provider’s account immediately. It is a material term of Provider’s
access to the Platform that its Billing Account information is and remains current,
complete and accurate. 
For each Assignment, PT Hippo shall remit to Candidate, Fees agreed to by such
Candidate and Provider pursuant to an order for those Candidate Services documented
pursuant to a properly submitted time sheet. PT Hippo makes no guarantees that
Candidates will be paid and Candidates acknowledge that payment is conditioned on PT
Hippo’s receipt of fees from Providers.
Cancellation Policy. You will be charged fifty percent (50%) of the Assignment as a
cancellation fee if you agree to engage a Candidate and you then cancel the Assignment.
The Provider will be charged a minimum of one hundred percent (100%) of the
Assignment if the Provider terminates a work assignment for any reason on the same day
as the work assignment.
PT Hippo may, in its sole discretion, terminate the account of any Candidate that
repeatedly does not perform Assignments that such Candidate has agreed to perform
without providing sufficient advance notice. In the event that a Provider cancels an
Assignment and has not provided advance notice of at least twenty four (24) hours as
agreed to by such Provider and the affected Candidate(s) or reasonable notice in the
absence of such an agreement, the affected Candidate(s) may notify PT Hippo. PT Hippo
shall include information on such cancellation of Assignments in its Ratings for
Providers. In the event that a Candidate does not perform an Assignment at all or does
not perform an Assignment in its entirety and in either case has not provided sufficient
advance notice of such non-performance or incomplete performance as agreed to by such
Candidate and the affected Provider or reasonable notice in the absence of such an
agreement, the affected Provider may notify PT Hippo.
4. Operation and Record Retention. PT Hippo reserves complete and sole discretion with
respect to the operation of the Site. PT Hippo may withdraw, suspend or discontinue any
functionality or feature of the Services, and may suspend, deactivate or terminate any
User at any time in its discretion. PT Hippo is responsible for maintaining data arising
from use of the Services, but does not warrant the accuracy or completeness of the data
stored; provided, however, the Provider at all times maintains custodianship of any such
data arising from use of the Services. PT Hippo reserves the right to maintain, delete or
destroy all communications and materials posted or updated to the Site pursuant to its
internal record retention and/or destruction policies.
5. Ownership of the Site and Related Materials. All information and data within the
Website (“Materials”) are the exclusive property of PT Hippo, or its licensors or
suppliers, as applicable. The Site is protected by United States and international
copyright and trademark laws, as applicable. Any Content, photos, artwork, videos, text,
graphics, articles and other information uploaded, posted, displayed or otherwise
provided by the Site (“Content”) and any Materials accessed through or made available
for use or download through the Site may not be copied, distributed, modified, published,
reproduced or used, in whole or in part, except for purposes authorized or approved in
writing by PT Hippo.
6. Use of the Site. You are solely responsible for the Content and information that you post,
upload, publish, link to, transmit, record, display or otherwise make available on the
Platform or transmit to other Users, including emails, photographs, voice notes,
recordings or profile text, whether publicly posted or privately transmitted. You represent
and warrant that all information that you submit upon registration is accurate and truthful
and that you will promptly update any information provided by you that subsequently
becomes inaccurate, misleading or false. PT Hippo reserves the right, in its sole
discretion, to investigate and take appropriate legal action against anyone who violates
this provision, including removing the offending communication from the Website or
Service and terminating or suspending the membership of such violators.
You understand and agree that PT Hippo may, but is not obligated to, monitor or review
any Content you post on the Website or as part of a Service. PT Hippo may delete any
Content, in whole or in part, that in the sole judgment of PT Hippo violates this
Agreement or may harm the reputation of the Website or PT Hippo.
Your use of the Website and Service, including all Content you post through the Service,
must comply with all applicable laws and regulations. You agree that PT Hippo may
access, preserve and disclose your account information and Content if required to do so
by law or in a good faith belief that such access, preservation or disclosure is reasonably
necessary, such as to: (i) comply with legal process; (ii) enforce this Agreement; (iii)
respond to claims that any Content violates the rights of third parties; (iv) respond to your
requests for customer service or allow you to use the Website in the future; or (v) protect
the rights, property or personal safety of PT Hippo or any other person.
7. Electronic Communications. When you use any of the Services, or send e-mails, text
messages and other communications from your desktop or mobile device to us, you are
communicating to PT Hippo electronically. You consent to receive communications
from PT Hippo electronically. You agree that (a) all agreements and consents can be
signed electronically and (b) all notices, disclosures, and other communications that PT
Hippo provides to you electronically satisfy any legal requirement that these notices and
other communications be in writing. These communications may be transactional or
relationship communications relating to the Services, such as administrative notices and
service announcements or changes, or emails containing commercial offers, promotions
or special offers from us or third party partners. Please see PT Hippo’s Privacy Policy for
more information regarding these communications.
8. Modifications to Service. PT Hippo reserves the right at any time to modify or
discontinue, temporarily or permanently, the Website or the Services (or any part thereof)
with or without notice. You agree that PT Hippo shall not be liable to you or to any third
party for any modification, suspension or discontinuance of the Service. To protect the
integrity of the Website or the Service, PT Hippo reserves the right at any time in its sole
discretion to block users from certain IP addresses from accessing the Website or Service.
9. Security. You are prohibited from violating or attempting to violate the security of the Site,
including, without limitation, (a) accessing data not intended for such User or logging onto a
server or an account which the User is not authorized to access; or (b) attempting to probe,
scan or test the vulnerability of a system or network or to breach security or authentication 
measures without proper authorization; or (c) accessing or using the Site or any portion
thereof without authorization, in violation of these Terms of Use or in violation of applicable
law. If you are under 18, you may use the PT Hippo only with consent and involvement of
a parent or guardian.
You may not use any scraper, crawler, spider, robot or other automated means of any kind to
access or copy data on the Site, deep-link to any feature or Content on the Site, bypass our
robot exclusion headers or other measures PT Hippo may use to prevent or restrict access to
the Site.
Violation of system or network security may result in civil or criminal liability. PT Hippo
will investigate occurrences that may involve such violations and may involve, and
cooperate with, law enforcement authorities in prosecuting users who are involved in such
violations. You agree not to use any device, software or routine to interfere or attempt to
interfere with the proper working of this Site or any activity being conducted on this Site.
10. Intellectual Property Rights; Prohibited Conduct
A. You agree and acknowledge that the Platform and Services, including without
limitation all of the Content on this Platform, including without limitation the
images, graphics, information, text, Ratings, data, links, as well as the underlying
software, network and systems that support this Platform and Services and other
material accessible through the Platform or Services (“Content”) is solely and
exclusively owned by or under license to PT Hippo and is protected by applicable
trademark, copyright, or other rights. As such, You agree that You shall not (1)
create or operate any platform, site or business that is based in whole or in part on
this Platform or the Services, (2) copy, reproduce, modify, create derivative
works, publish, distribute, transmit, publicly display or post on any other Platform
or to any third party any Content without the prior written consent of PT Hippo on
a case by case basis, or (3) reverse engineer, decompile, disassemble, modify,
distribute, reproduce, republish or sell in any form or by any means, in whole or
in part, any of the Content.. Subject to Your compliance with these Terms of Use,
PT Hippo hereby grants to You a non-transferable, non-sublicensable, nonexclusive,
revocable, and limited right to access and use the Platform and its
Content solely for Your internal business purposes as an Provider or personal use
as a Candidate.
B. Content Ownership and License. PT Hippo does not claim ownership of any
Content submitted by Users. By submitting such Content, however, You hereby
grant PT Hippo a world-wide, royalty-free, perpetual, irrevocable, non-exclusive
license to use, distribute, reproduce, modify, adapt, create derivative works from,
publicly perform and/or display such Content, subject to the restrictions set forth
in these Terms of Use or the Privacy Policy .. This license shall remain in effect
until PT Hippo deletes the Content from PT Hippo’s systems.PT Hippo reserves
the right to terminate and/or temporarily disable the accounts of Users who
repeatedly infringe the intellectual property rights, including without limitation
copyrights, of others.
C. In connection with Your accessing the Platform, Services, or PT Hippo’s online
messaging service, Rating system, or any other Service provided through the
Platform, You shall abide by the following standards of conduct. You shall not,
and will not authorize or facilitate any attempt by another person, to use the
Platform or any messaging service, Ratings system or other Service.
11. Confidentiality. You shall not use or disclose any proprietary or confidential information
with which You obtain or otherwise gain access to as a result of Your access to or usage
of the Platform or Services. All information regarding an Assignment between the
Candidate and an Provider who sent such Assignment, whether or not in writing, of a
private, secret or confidential nature concerning the Provider’s business or financial
affairs (collectively, “Proprietary Information”) is and shall be the exclusive property of
such Provider. By way of illustration, but not limitation, Proprietary Information may
include the contents of an Assignment, products, product improvements, product
enhancements, processes, methods, techniques, negotiation strategies and positions,
projects, developments, plans (including business and marketing plans), research data,
financial data (including sales costs, profits, pricing methods), personnel data, computer
programs (including software used pursuant to a license agreement), customer, prospect
and supplier lists, and contacts at or knowledge of customers or prospective customers of
the Provider, and patient medical or dental records and You will not disclose any
Proprietary Information to any person or entity other than the applicable Provider or use
the same for any purposes (other than in the performance of Your duties as stipulated in
the Assignment) without written approval by an Provider of such Provider, unless and
until such Proprietary Information has become public knowledge without Your fault.
";
        public static string termsofused2 = @"You shall not utilize the services of another company or similar type entity that offers
Services similar to those offered by PT Hippo, without consent of PT Hippo. You shall
promptly notify PT Hippo in writing of the name of any User or third party, that attempts
to contact You outside the Platform with the intent of entering into an agreement or
contract with you by circumventing the Platform. You agree to cooperate with PT Hippo
to establish with such entity that PT Hippo was solely responsible for the introduction of
the between the User and You.
While fulfilling the obligations of an Assignment for the Provider, a Candidate will use
his/her best efforts to prevent unauthorized publication or disclosure of any of the
Provider’s Proprietary Information. Candidate agrees that all files, documents, letters,
memoranda, reports, records, data, sketches, drawings, models, program listings,
computer equipment or devices, computer programs or other written, photographic, or
other tangible or intangible material containing Proprietary Information, whether created
by such Candidate or others, which shall come into his/her custody or possession, shall be
and are the exclusive property of Provider to be used by Candidate only in the
performance of his/her duties for the Provider and shall not be copied or removed from
Provider’s premises except in the pursuit of the business of Provider as required to
perform an Assignment.
12. Independent Contractor. Status as Independent Contractor. Nothing in these Terms of
Use will be construed as creating a partnership, joint venture, or employer-employee
relationship, nor will Candidate be construed as PT Hippo’s or an Provider’s employee,
agent, franchisee or servant. The Services shall be rendered on an independent contractor
basis, not as an employee, agent, or partner of PT Hippo. Nothing hereunder shall be
construed as establishing a partnership, joint venture or similar relationship between the
PT Hippo and Users. Users agree to be solely responsible for all taxes and other
withholdings relating to the fee income that is paid to other Users. Users do not have the
authority to bind PT Hippo and enter into a contract on behalf of PT Hippo.
13. Rating System; Online Messaging System; Electronic Communications.
A. Ratings. As a User of the Platform, You agree and acknowledge that You may
rate (on the Platform) the performance of other Users whom with You transact
business, and You understand that Users may rate Your performance (collectively
or individually, “Ratings”) on the Platform as well. Candidates may be rated on
various parameters including without limitation the quality of the Assignment
performed and timeliness. Providers may be rated on various parameters
including without limitation and payment history. Any Ratings that are provided
by Users are solely the evaluation or rating of such Counterparty. PT Hippo
disclaims any responsibility for the accuracy or quality of any Ratings. User
acknowledges and agrees that PT Hippo reserves the right, without prior notice
and in its sole discretion, to decide whether the content of Ratings violate these
Terms of Use for any reason. If PT Hippo believes that Your Ratings contain
inappropriate Content, PT Hippo may remove the Content of such Ratings, in
whole or in part, and/or terminate Your access to PT Hippo’s Services. PT Hippo
reserves the right to remove any Ratings, in whole or in part, from PT Hippo’s
Platform at any time and its PT Hippo’s sole discretion. If the content of such
Ratings are found to be defamatory or legally actionable in a court of law, the
User(s) responsible for posting such Content will be held exclusively responsible,
and PT Hippo will bear no responsibility.
B. Online Messaging System. PT Hippo may offer an online messaging system, as
determined by PT Hippo from time to time. Users shall use such messaging
system as permitted herein.
C. Responsibility for Ratings. PT Hippo is not responsible or liable for the conduct
of Users or for views, opinions and statements expressed in Content submitted for
public display through its Platform, such as through an online messaging system,
or for Content that is privately displayed to registrants of the Platform, such as
Ratings of Providers and Candidates. PT Hippo does not prescreen information
exchanged in online messaging systems or listed in Provider and Candidate
Ratings. With respect to such messaging systems and Ratings systems, PT Hippo
acts as a passive conduit for distribution and PT Hippo is not responsible for the
Content contained therein. Any opinions, advice, statements, services, offers, or
other information in Content expressed or made available by Users of an online
messaging system or Ratings system are those of the respective author(s) or 
distributor(s) and not of PT Hippo. PT Hippo neither endorses nor guarantees the
accuracy, completeness, or usefulness of any such Content. PT Hippo is
responsible for ensuring that Content submitted to this Platform is not provided in
violation of any copyright, trade secret or other intellectual property rights of
another person or entity. You shall be solely liable for any damages resulting from
infringement of copyrights, trade secret, or other intellectual property rights, or
any other harm resulting from Your uploading, posting or submission of Content
to this Platform.";
        
        public static string termsofused3 = @"
D. Monitoring. PT Hippo has the right, but not the obligation, to monitor Content
submitted to the Platform through an online messaging or Rating system to assess
compliance with these Terms of Use and any other applicable rules that PT Hippo
may establish. PT Hippo has the right in PT Hippo’s sole discretion to edit or
remove any material submitted to or exchanged in any online messaging system
or Ratings system provided through this Platform. Without limiting the foregoing,
PT Hippo has the right to remove any material that PT Hippo, in its sole
discretion, finds to be in violation of these Terms of Use or otherwise
objectionable, and You are solely responsible for the Content that You post to this
Platform.
E. Consent to Electronic Communications. You consent to receiving all documents,
agreements and other communications (collectively, “Communications”) from PT
Hippo electronically. PT Hippo may make Communications available via its
methods for contacting You on the Platform or through an email address that You
provide to PT Hippo. Communications may include without limitation
information on offers for Assignments or acceptance of offers for Assignments,
updates to PT Hippo’s Terms of Use or Privacy Policy, statements related to Your
account, federal and state tax statements, and other information that PT Hippo
may provide from time to time. To receive such Communications, You may need
certain hardware and software, as specified by PT Hippo from time to time. If
You would like to receive a written copy of Communications, You acknowledge
that there may be a delay in providing You with a copy, You must have provided
PT Hippo with an accurate physical address, and You agree to pay the reasonable
fees assessed by PT Hippo for delivering You such Communications to a physical
address specified by You. If Your email address becomes invalid or electronic
Communications are otherwise returned to PT Hippo, PT Hippo reserves the right
to terminate Your account.
14. Taxes. PT Hippo is only a venue for connecting Providers that require short-term
Assignments with Candidates who can provide such Assignments. You are solely
responsible for understanding and evaluating any tax liability related to the request or
delivery of Assignments through the Platform, and for determining the need to report any
Assignments pursuant to the requirements of local, state, or federal law. PT Hippo cannot
and does not offer tax advice to Users nor does PT Hippo provide any tax documentation
to Users; PT Hippo recommends that You consult with a tax advisor for such advice and
documentation. You are solely responsible for any taxes arising from Your use of the 
Platform, any Content contained therein, and for the Services that You request or perform
therein, excluding PT Hippo’s income. Candidates who are U.S. citizens or other U.S.
persons (as defined in IRS Form W-9) are required to provide a completed IRS Form W9,
to be updated annually, or upon any change in the Candidate’s tax status and/or change
in the Candidate’s name or TIN. Other Users are required to provide the data necessary to
complete the necessary tax reporting forms, to be updated annually, or upon any change
in the Users’ tax status and are required to complete IRS Form W-8. Neither Approved
Payroll Provider nor PT Hippo are required to make any payments to a Candidate who
has not provided the foregoing information.
15. Termination
A. Termination by PT Hippo. PT Hippo may terminate any User’s access to the
Platform, in PT Hippo’s sole discretion, for any reason and at any time, with or
without prior notice. It is PT Hippo’s policy to terminate Users who violate these
Terms of Use, as deemed appropriate in PT Hippo’s sole discretion, but PT Hippo
may also terminate access as provided for in the preceding sentence. PT Hippo
may terminate Your access to the Platform if You do not use Your Account for a
lengthy period, as determined by PT Hippo from time to time in its sole
discretion. You agree that PT Hippo is not liable to You or any third party for any
termination of Your access to the Platform.
B. Termination by You. You may terminate Your Account at any time by deleting
Your Account. If You are an Provider and You delete Your Account while
outstanding payments are due to one or more Candidates with whom You have
transacted business, You agree and acknowledge that PT Hippo reserves the right
to make any payments due to such Candidate(s). If You are a Candidate that is
owed money by an Provider, PT Hippo will make a good faith attempt to deliver
any such amount to Your address on record in Your Profile page. Candidate
acknowledges that the risk that an Provider with the Candidate transacts business
may default on payment obligations is borne by the Candidate voluntarily and
entirely at the Candidate’s own risk. PT Hippo disclaims all responsibility related
to such transactions.
C. Reactivation. Provided that You deleted Your Account or You allowed Your
Account to lapse by not using Your Account for a sufficiently long period, You
may reactivate Your Account by following the process set forth by PT Hippo
from time to time, during a time period established by PT Hippo from time to
time following the deletion or deactivation of Your Account. If Your Account
may no longer be reactivated, PT Hippo may, in its discretion, permit You to
create a new account.
16. Links to Other Sites. The Website may contain, and the Services or third parties may
provide, advertisements and promotions offered by third parties and links to other web
sites or resources. You acknowledge and agree that PT Hippo is not responsible for the
availability of such external websites or resources, and does not endorse and is not
responsible or liable for any content, information, statements, advertising, goods or
services, or other materials on or available from such websites or resources. Your
correspondence or business dealings with, or participation in promotions of, third parties 
found on or through the Website or Services, including payment and delivery of related
goods or services, and any other terms, conditions, warranties or representations
associated with such dealings, are solely between you and such third party. You further
acknowledge and agree that PT Hippo shall not be responsible or liable, directly or
indirectly, for any damage or loss caused or alleged to be caused by or in connection with
the use of, or reliance upon, any such content, information, statements, advertising, goods
or services or other materials available on or through any such website or resource.
17. Claims of Copyright Infringement. PT Hippo disclaims any responsibility or liability
for copyrighted Materials posted on our site. If you believe that your work has been
copied in a manner that constitutes copyright infringement, please follow the procedures
set forth below. PT Hippo respects the intellectual property rights of others and expects
its users to do the same. In accordance with the Digital Millennium Copyright Act
(“DMCA”), PT Hippo will respond promptly to notices of alleged infringement that are
reported to the PT Hippo. Designated Copyright Agent, identified below. If you are a
copyright owner, authorized to act on behalf of one, or authorized to act under any
exclusive right under copyright, please report alleged copyright infringements taking
place on or through our Site by sending PT Hippo a notice complying with the
requirements of the DMCA. If PT Hippo removes Content in response to a copyright or
trademark notice, PT Hippo will notify you and offer to provide you with a copy of the
notice, as applicable. If you believe Content was wrongly removed due to a mistake or
misidentification of the Material, you can file a counter-notice with PT Hippo.
18. Disclaimers. You acknowledge and agree that neither PT Hippo nor its affiliates and
third party partners are responsible for and shall not have any liability, directly or
indirectly, for any loss or damage, including personal injury or death, as a result of or
alleged to be the result of (i) any incorrect or inaccurate Content posted on the Website or
provided in connection with the Services, whether caused by Users or any of the
equipment or programming associated with or utilized in the Website or Services; (ii) the
timeliness, deletion or removal, incorrect delivery or failure to store any Content,
communications or personalization settings; (iii) the conduct, whether online or offline,
of any User; or (iv) any error, omission or defect in, interruption, deletion, alteration,
delay in operation or transmission, theft or destruction of, or unauthorized access to, any
User or User communications.. TO THE MAXIMUM EXTENT ALLOWED BY
APPLICABLE LAW, PT HIPPO PROVIDES THE WEBSITE AND THE
SERVICE ON AN 'AS IS' AND 'AS AVAILABLE' BASIS AND GRANTS NO
WARRANTIES OF ANY KIND, WHETHER EXPRESS, IMPLIED, STATUTORY
OR OTHERWISE WITH RESPECT TO THE SERVICE OR THE WEBSITE
(INCLUDING ALL CONTENT CONTAINED THEREIN), INCLUDING
(WITHOUT LIMITATION) ANY IMPLIED WARRANTIES OF
SATISFACTORY QUALITY, MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE OR NON-INFRINGEMENT. PT HIPPO DOES NOT
REPRESENT OR WARRANT THAT THE WEBSITE OR SERVICE WILL BE
UNINTERRUPTED OR ERROR FREE, SECURE OR THAT ANY DEFECTS OR
ERRORS ON THE WEBSITE OR IN THE SERVICE WILL BE CORRECTED.
a. ANY MATERIAL DOWNLOADED OR OTHERWISE OBTAINED
THROUGH THE USE OF THE SERVICE OR WEBSITE IS ACCESSED AT
YOUR OWN DISCRETION AND RISK, AND YOU WILL BE SOLELY
RESPONSIBLE FOR AND HEREBY WAIVE ANY AND ALL CLAIMS AND
CAUSES OF ACTION WITH RESPECT TO ANY DAMAGE TO YOUR
COMPUTER SYSTEM, INTERNET ACCESS, DOWNLOAD OR DISPLAY
DEVICE, OR LOSS OR CORRUPTION OF DATA THAT RESULTS OR MAY
RESULT FROM THE DOWNLOAD OF ANY SUCH MATERIAL. IF YOU DO
NOT ACCEPT THIS LIMITATION OF LIABILITY, YOU ARE NOT
AUTHORIZED TO DOWNLOAD OR OBTAIN ANY MATERIAL THROUGH
THE SERVICE OR WEBSITE.
b. From time to time, PT Hippo may make third party opinions, advice, statements,
offers, or other third party information or content available on the Website and/or
through the Service. All third party content is the responsibility of the respective
authors thereof and should not necessarily be relied upon. Such third party authors
are solely responsible for such content. PT HIPPO DOES NOT: (I)
GUARANTEE THE ACCURACY, COMPLETENESS, OR USEFULNESS OF
ANY THIRD PARTY CONTENT ON THE WEBSITE OR PROVIDED
THROUGH THE SERVICE, OR (II) ADOPT, ENDORSE OR ACCEPT
RESPONSIBILITY FOR THE ACCURACY OR RELIABILITY OF ANY
OPINION, ADVICE, OR STATEMENT MADE BY ANY PARTY THAT
APPEARS ON THE WEBSITE OR SERVICE. UNDER NO
CIRCUMSTANCES WILL PT HIPPO OR ITS AFFILIATES BE
RESPONSIBLE OR LIABLE FOR ANY LOSS OR DAMAGE RESULTING
FROM YOUR RELIANCE ON INFORMATION OR OTHER CONTENT
POSTED ON THE WEBSITE OR SERVICE, OR TRANSMITTED TO OR BY
ANY USERS.
19. Limitation of Liability Regarding Use of Site. PT HIPPO IS NOT ENGAGED IN THE
PRACTICE OF MEDICINE, DOES NOT PROVIDE MEDICAL SERVICES, AND IS
NOT IN THE BUSINESS OF RENDERING HEALTH CARE. ALL OF THE
PROVIDERS ARE INDEPENDENT OF PT HIPPO AND USE THE SERVICES AS A
WAY TO COMMUNICATE WITH YOU. ANY INFORMATION OR ADVICE
RECEIVED FROM A PROVIDER COMES FROM THEM ALONE. YOUR
INTERACTIONS WITH THE PROVIDERS SHOULD NOT TAKE THE PLACE OF
YOUR RELATIONSHIP WITH YOUR REGULAR HEALTH CARE
PRACTITIONERS. YOU SHOULD ALWAYS SEEK THE ADVICE OF YOUR
PROVIDERS WITH ANY QUESTIONS OR CONCERNS YOU MAY HAVE
REGARDING INDIVIDUAL NEEDS AND ANY MEDICAL CONDITIONS. PT
HIPPO SHALL NOT BE LIABLE FOR ANY PROFESSIONAL ADVICE OBTAINED
FROM A PROVIDER VIA THE SERVICES OR FOR ANY OTHER INFORMATION
OBTAINED ON THE SITE. YOU ACKNOWLEDGE THAT RELIANCE ON ANY
PROVIDERS OR INFORMATION PROVIDED BY THE PROVIDERS THROUGH
THE SERVICES IS SOLELY AT YOUR OWN RISK AND YOU ASSUME FULL
RESPONSIBILITY FOR ALL RISK ASSOCIATED HEREWITH. PT HIPPO DOES
NOT MAKE ANY REPRESENTATIONS OR WARRANTIES ABOUT THE 
TRAINING OR SKILL OF ANY PROVIDERS WHO PROVIDE SERVICES
THROUGH THE SITE.
PT HIPPO IS NOT RESPONSIBLE NOR LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, CONSEQUENTIAL, SPECIAL, EXEMPLARY, PUNITIVE, OR
OTHER DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION,
THOSE RESULTING FROM LOST PROFITS, LOST DATA, OR BUSINESS
INTERRUPTION) ARISING OUT OF OR RELATING IN ANY WAY TO THE SITE,
SITE-RELATED SERVICES, CONTENT OR INFORMATION CONTAINED
WITHIN THE SITE, AND/OR ANY LINKED WEBSITE, WHETHER BASED ON
WARRANTY, CONTRACT, TORT, OR ANY OTHER LEGAL THEORY AND
WHETHER OR NOT ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.
YOUR SOLE REMEDY FOR DISSATISFACTION WITH THE SITE, SITERELATED
SERVICES, AND/OR LINKED WEBSITES IS TO STOP USING THE
SITE AND/OR THOSE SERVICES. TO THE EXTENT ANY ASPECTS OF THE
FOREGOING LIMITATIONS OF LIABILITY ARE NOT ENFORCEABLE, THE
MAXIMUM LIABILITY OF PT HIPPO TO YOU WITH RESPECT TO YOUR USE
OF THIS SITE IS $75.00 (SEVENTY FIVE DOLLARS).
20. Indemnification. You hereby agree to indemnify and hold harmless PT Hippo, PT
Hippo’s affiliates, and each of its and their respective directors, officers, managers,
employees, members, agents, representative, licensors, successors, and assigns from and
in respect of any and all losses, damages, expense, claims, charges, obligations,
liabilities, commitments, actions, proceedings, demands, judgments, assessments,
penalties, costs, and expenses (including, without limitation, court costs, reasonable
attorneys' fees and other reasonable professional fees and costs) and damages of any kind
whatsoever, arising out of: (a) use of the Services; or (b) violation of these Terms of Use.
21. Dispute Resolution. PT Hippo will try work in good faith to resolve any issue you have
with the Site, including Services ordered or purchased through the Site, if you bring that
issue to the attention of our customer service department. However, PT Hippo realizes
that there may be rare cases where PT Hippo may not be able to resolve an issue to a
customer’s satisfaction. In the event PT Hippo cannot resolve a dispute between us, you
agree that all matters related to any use or access of the Site, the Services or the Terms of
Use will be governed by the laws of the State of New York, without regard to its conflicts
of laws rules. You hereby waive any objections to such jurisdiction or venue. Any
claims or controversies arising out of or relate to the use and access of the Site shall be
exclusively in state courts of Nassau County, New York.
22. Force Majeure. PT Hippo will not be deemed to be in breach of these Terms of Use or
liable for any breach of these terms or our privacy policy due to any event or occurrence
beyond our reasonable control, including without limitation, acts of God, terrorism, war,
invasion, failures of any public networks, electrical shortages, earthquakes or floods, civil
disorder, strikes, fire or other disaster.
23. Right to Modify Revisions. PT Hippo reserves the right, in its sole discretion, to
terminate your access to all or part of this Site, with or without cause, and with or without
notice. PT Hippo reserves the right, in its sole discretion to modify these Terms of Use at
any time, effective upon posting. Any use of this Site after such changes will be deemed
an acceptance of those changes. You agree to review the Terms of Use each time you
access this Site so that you may be aware of any changes to these Terms. In the event
that any of the Terms of Use are held by a court or other tribunal of competent
jurisdiction to be unenforceable, such provisions shall be limited or eliminated to the
minimum extent necessary so that these Terms of Use shall otherwise remain in full force
and effect. These Terms of Use constitute the entire agreement between PT Hippo and
you pertaining to the subject matter hereof. In its sole discretion, PT Hippo may from
time-to-time revise these Terms of Use by updating this posting. You should, therefore,
periodically visit this page to review the current Terms of Use, so you are aware of any
such revisions to which you are bound. Certain provisions of these Terms of Use may be
superseded by expressly designated legal notices or terms located on particular pages
within this Site.
24. Miscellaneous. You may not assign these Terms without PT Hippo's prior written
approval. PT Hippo may assign these Terms without your consent to: (i) a subsidiary or
affiliate; (ii) an acquirer of PT Hippo's equity, business or assets; or (iii) a successor by
merger. Any purported assignment in violation of this section shall be void. No joint
venture, partnership, employment, or agency relationship exists between you, PT Hippo
or any third party provider as a result of this Agreement or use of the Services. If any
provision of these Terms is held to be invalid or unenforceable, such provision shall be
struck and the remaining provisions shall be enforced to the fullest extent under law. PT
Hippo's failure to enforce any right or provision in these Terms shall not constitute a
waiver of such right or provision unless acknowledged and agreed to by PT Hippo in
writing. In addition to accrued obligations, the following sections may survive the
termination or expiration of these Terms of Use: Section 10(b) (Content Ownership and
License), Section 11(Confidentiality), Section 13(c) (Responsibility for Ratings), Section
14 (Taxes), Section 18 (Disclaimers), Section 19 (Limitation of Liability), Section 20
(Indemnification), Section 21 (Limitation of Liability), Section 21 (Dispute Resolution),
and Section 24 (Miscellaneous).";
        //" " + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " +
        //  "\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" +
        //  "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" +
        //  "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa." +
        //  "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " + "\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" +
        //  "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa." + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " + "\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa." + " " + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " +
        //  "\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" +
        //  "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " +
        //  "\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" +
        //  "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n";


public static string useragremeenttext = @"PT Hippo, INC (“PT Hippo” or “We”) operates a digit platform which is located at
www.PTHippo.com (the “Website or the “Site”) and includes all related sub-domains, mobile
versions, tools, and services (collectively, the “Platform”). The PT Hippo Platform connects
medical service providers (each a “Provider”, and collectively, “Providers”) seeking of
temporary and/or replacement practitioners with third party individuals (each a “Candidate” and
collectively, “Candidates”) who render physical therapy services (the “Services”). Providers and
Candidates together are collectively referred to as “Users” and each individually as a “User”. PT
Hippo respects the privacy of its Users and has developed this Privacy Policy to demonstrate its
commitment to protecting your privacy. This Privacy Policy describes the information we
collect, how that information may be used, with whom it may be shared, and your choices about
such uses and disclosures. We encourage you to read this Privacy Policy carefully when using
our Website or Services or transacting business with us. By using our Website, application, or
Services, you are accepting the practices described in this Privacy Policy.
If you have any questions about our privacy practices, please refer to the end of this Privacy
Policy for information on how to contact us.
1. Information we collect about you
In General. We may collect personal information, business related information, and other
information deemed necessary by PT Hippo. We may also collect your geolocation information
with your consent. We may collect this information through a Website, mobile application or
other online service. When you provide Personal Information it may be sent to servers located in
the United States and other countries around the world.
• Information you provide. We may collect and store any personal information you enter
on our Website or provide to us in some other manner. This includes identifying
information, such as your name, address, email address, and telephone number, and, if
you transact business with us, financial information such as your payment method (valid
credit card number, type, expiration date or other financial information).Additionally PT
Hippo may collect and store personal information about other people that you provide to
us, such as their name, address and email address.
Use of cookies and other technologies to collect information. We use various technologies to
collect information from your device and about your activities on our site or application.
• Information collected automatically. We automatically collect information from your
browser or device when you visit our Website or application. This information could
include your IP address, device ID, your browser type and language, access times, the
content of any undeleted cookies that your browser previously accepted from us
(See 'Cookies'below) and the referring Website address.
• Cookies and Use of Cookie Data. When you visit our Website or application, we may
assign your device one or more cookies to facilitate access to our site and to personalize
your online experience. Through the use of a cookie, we also may automatically collect
information about your online activity on our site, such as the web pages you visit, the 
time and date of your visits, the links you click, and the searches you conduct on our site.
Most browsers automatically accept cookies, but you can usually modify your browser
setting to decline cookies. If you choose to decline cookies, please note that you may not
be able to sign in or use some of the interactive features offered on our Website.
• Other Technologies. We may use standard Internet technology, such as web beacons,
pixel tags, local storage and other technologies that facilitate personalization to track your
use of our site. We also may use these technologies in advertisements or email messages
to determine whether messages have been opened and acted upon. The information we
obtain in this manner enables us to customize the services we offer our Website visitors
to deliver targeted advertisements and to measure the overall effectiveness of our online
advertising, content, programming or other activities.
• Information collected by third-parties. We may allow service providers, advertising
companies and ad networks, and other third parties to display advertisements on our site.
These companies may use tracking technologies, such as cookies, to collect information
about users who view or interact with their advertisements. Our Website does not provide
any personal information to these third parties. This information allows them to deliver
targeted advertisements and gauge their effectiveness.
2. How we use the information we collect
In General.
We may use information that we collect about you to:
• deliver our products and Services, and manage our business;
• manage your account and provide you with customer support ;
• perform research and analysis about your use of, or interest in, our products, Services, or
content, or products, Services or content offered by others ;
• communicate with you by email, postal mail, telephone and/or mobile devices about
products or Services that may be of interest to you either from us or other third parties;
• develop and display content and advertising tailored to your interests on our site and
other sites, including providing our advertisements to you when you visit other sites ;
• perform ad tracking and Website or mobile application analytics ;
• verify your eligibility and deliver prizes in connection with contests and sweepstakes ;
• enforce or exercise any rights in our terms and conditions ; and
• perform functions as otherwise described to you at the time of collection.
Financial information. We may use financial information or payment method to process
payment for any purchases, enroll you in the discount, rebate, and other programs in which you
elect to participate, to protect against or identify possible fraudulent transactions, and otherwise
as needed to manage our business
3. With whom we share your information
Personal information. We do not share your personal information with others except as
indicated below or when we inform you and give you an opportunity to opt out of having your
personal information shared. We may share personal information with:
• Service providers. We may share information, including personal information, with third
parties that perform certain services on our behalf. These services may include fulfilling 
orders, providing customer service and marketing assistance, performing business and
sales analysis and ad tracking and analytics. We may also share your name, contact
information and credit card information with our service providers who process credit
card payments. These service providers may have access to personal information needed
to perform their functions but are not permitted to share or use such information for any
other purposes.
• Business partners. When you register or make purchases on our Website or clickthrough
our advertisements offered on third party Websites or applications, we may share
personal information with the businesses with which we partner to offer you the
applicable products, services or any advertisements. When you elect to engage in a
particular merchant's offer or program, you authorize us to provide your email address
and other information to that merchant. To opt-out of cookies that may be set by third
party data or advertising partners, please go to https://www.aboutads.info/choices/.
• Other Situations . We also may disclose your information, including personal
information:
o In response to a subpoena or similar investigative demand, a court order, or a
request for cooperation from a law enforcement or other government agency; to
establish or exercise our legal rights; to defend against legal claims; or as
otherwise required by law. In such cases, we may raise or waive any legal
objection or right available to us.
o When we believe disclosure is appropriate in connection with efforts to
investigate, prevent, or take other action regarding illegal activity, suspected fraud
or other wrongdoing; to protect and defend the rights, property or safety of our
company, our users, our employees, or others; to comply with applicable law or
cooperate with law enforcement; or to enforce our Website terms and conditions
or other agreements or policies.
o In connection with a substantial corporate transaction, such as the sale of our
business, a divestiture, merger, consolidation, or asset sale, or in the unlikely
event of bankruptcy.
Aggregated and/or non-personal information. We may share non-personal information we
collect under any of the above circumstances. We may combine non-personal information we
collect with additional non-personal information collected from other sources. We also may
share aggregated, non-personal information, or personal information in hashed, non-human
readable form, with third parties, including advisors, advertisers and investors, for the purpose of
conducting general business analysis, advertising, marketing or other business purposes. For
example, we may engage a data provider who may collect web log data from you (including IP
address and information about your browser or operating system), or place or recognize a unique
cookie on your browser to enable you to receive customized ads or content. The cookies may
reflect de-identified demographic or other data linked to data you voluntarily have submitted to
us (such as your email address), that we may share with a data provider solely in hashed, nonhuman
readable form. To opt out of the sharing of your geolocation information, please visit the
'Account Settings' page for your account.
If you would like to opt-out of third-party mobile application ad tracking and analytics, please
visit here.
4. Do Not Track Disclosure
Do Not Track ('DNT') is a privacy preference that users can set in their web browsers. DNT is a
way for users to inform Websites and services that they do not want certain information about
their webpage visits collected over time and across Websites or online services. We are
committed to providing you with meaningful choices about the information we collect and that is
why we provide the opt-out links in the Privacy Policy. However, we do not recognize or
respond to any DNT signals as the Internet industry works toward defining exactly what DNT
means, what it means to comply with DNT, and a common approach to responding to DNT.
5. Third-party Websites
There are a number of places on our Website where you may click on a link to access other
Websites that do not operate under this Privacy Policy. For example, if you click on an
advertisement on our Website, you may be taken to a Website that we do not control. These
third-party Websites may independently solicit and collect information, including personal
information, from you and, in some instances, provide us with information about your activities
on those Websites. We recommend that you consult the privacy statements of all third-party
Websites you visit by clicking on the 'privacy' link typically located at the bottom of the
webpage you are visiting
6. How you can access your information
If you have an online account with us, you have the ability to review and update your personal
information online by logging into your account and clicking on your account settings.
Applicable privacy laws may allow you the right to access and/or request the correction of errors
or omissions in your personal information that is in our custody or under our control. Our
Privacy Officer will assist you with the access request. This includes:
1. Identification of personal information under our custody or control; and
2. Information about how personal information under our control may be or has been used
by us.
We will respond to requests within the time allowed by all applicable privacy laws and will make
every effort to respond as accurately and completely as possible. Any corrections made to
personal information will be promptly sent to any organization to which it was disclosed. In
certain exceptional circumstances, we may not be able to provide access to certain personal
information we hold. For security purposes, not all personal information is accessible and
amendable by the Privacy Officer. If access or corrections cannot be provided, we will notify the
individual making the request within 30 days, in writing, of the reasons for the refusal.
7. Data retention
If you have an online account with us, you may close your account at any time by visiting the
'Account Settings' page for your account. After you close your account, you will not be able to
sign in to our Website or access any of your personal information. However, you can open a
new, separate account at any time or re-activate your previous account by following instructions
we will give you at the time you close your account. If you close your account, we may still
retain certain information associated with your account for analytical purposes and
recordkeeping integrity, as well as to prevent fraud, collect any fees owed, enforce our terms and
conditions, take actions we deem necessary to protect the integrity of our Website or our users,
or take other actions otherwise permitted by law. In addition, if certain information has already 
been provided to third parties as described in this Privacy Policy, retention of that information
will be subject to those third parties' policies
8. Your choices about collection and use of your information
You can choose not to provide us with certain information, but that may result in you being
unable to use certain features of our site because such information may be required in order for
you to register as a member; purchase products or services; participate in a contest, promotion, or
survey; ask a question; or initiate other transactions. When you register on our site, you consent
to receive email messages from us. At any time you can choose to no longer receive commercial
or promotional emails from us by accessing the Platform. You also will be given the opportunity,
in any commercial email that we send to you, to opt out of receiving such messages in the future.
It may take up to 10 days for us to process an opt-out request. We may send you transactional
emails, such as service announcements, administrative notices, and surveys, without offering you
the opportunity to opt out of receiving them. Please note that changing information in your
account, or otherwise opting out of receipt of promotional email communications, will only
affect future activities or communications from us. If we have already provided your information
to a third party (such as a service provider) before you have changed your preferences or updated
your information, you may have to change your preferences directly with that third party.
9. How we protect your personal information
We take appropriate security measures (including physical, electronic and procedural measures)
to help safeguard your personal information from unauthorized access and disclosure. We want
you to feel confident using our Website to transact business. However, no system can be
completely secure. Therefore, although we take steps to secure your information, we do not
promise, and you should not expect, that your personal information, searches, or other
communications will always remain secure. Users should also take care with how they handle
and disclose their personal information and should avoid sending personal information through
insecure email. Please refer to the Federal Trade Commission's Website
at https://www.ftc.gov/bcp/menus/consumer/data.shtm for information about how to protect
yourself against identity theft. You agree that we may communicate with you electronically
regarding security, privacy, and administrative issues, such as security breaches. We may post a
notice on our Service if a security breach occurs. We may also send an email to you at the email
address you have provided. You may have a legal right to receive this notice in writing. To
receive free written notice of a security breach (or to withdraw your consent from receiving
electronic notice), please notify us at the Site.
10. Information you provide about yourself while using our service
We provide areas on our site where you can post information about yourself and others and
communicate with others or upload content such as photographs. Such postings are governed by
our Terms of Use. In addition, such postings may appear on other Websites or when searches
are executed on the subject of your posting. Also, whenever you voluntarily disclose personal
information on the Website, that information will be publicly available and can be collected and
used by others. We cannot control who reads your posting or what other users may do with the
information you voluntarily post, so we encourage you to exercise discretion and caution with
respect to your personal information
11. Onward transfer and consent to international processing
While our primary data centers are in the United States, we may transfer personal information or
other information to our offices outside of the United States. In addition, we may employ other
companies and individuals to perform functions on our behalf. If we disclose personal
information to a third party or to our employees outside of the United States, we will seek
assurances that any information we may provide to them is safeguarded adequately and in
accordance with this Privacy Policy and the requirements of applicable privacy laws.
If you are visiting from the European Union or other regions with laws governing data collection
and use, please note that you are agreeing to the transfer of your personal data, including
sensitive data, by the Website from your region to countries which do not have data protection
laws that provide the same level of protection that exists in countries in the United States. By
providing your personal information, you consent to any transfer and processing in accordance
with this Policy.
12. No Rights of Third Parties
This Privacy Policy does not create rights enforceable by third parties or require disclosure of
any personal information relating to users of the Website
13. Changes to this Privacy Policy
We will occasionally update this Privacy Policy. When we post changes to this Privacy Policy,
we will revise the 'last updated' date at the top of this Privacy Policy. We recommend that you
check our Website from time to time to inform yourself of any changes in this Privacy Policy or
any of our other policies.
14. Linked information
Cookies:
A cookie is a small text file that is stored on a user's computer for record keeping purposes.
Cookies can be either session cookies or persistent cookies. A session cookie expires when you
close your browser and is used to make it easier for you to navigate our Website. A persistent
cookie remains on your hard drive for an extended period of time. Cookies on our Website do
not link to or store your personal information.
For example, when you sign in to our Website, we will record the name associated with each
User in the cookie file on your computer. We also may record your password in this cookie file,
if you indicated that you would like your password saved for automatic sign-in. For security
purposes, we will encrypt any usernames, passwords, and other user or member account-related
data that we store in such cookies. We may allow our authorized service providers to serve
cookies from our Website to allow them to assist us in various activities, such as doing analysis
and research on the effectiveness of our site, content and advertising.
We may allow third-parties, including advertising companies, analytics companies, and ad
networks, to display advertisements on our site. These companies may use tracking technologies,
such as cookies, to collect information about users who view or interact with their
advertisements or our Website or mobile applications. We do not provide any non-masked or
non-obscured personal information to these third parties, but they may collect information about
where you, or others who are using your device, saw and/or clicked on the advertisements they 
deliver (such as click stream information, browser type, time and date, subject of advertisements
clicked or scrolled over, etc.), and possibly associate this information with your subsequent visits
to the advertised Websites or other data they have collected. They also may combine this
information with personal information they collect from you to provide advertisements about
goods and services likely to be of greater interest to you. The collection and use of that
information is subject to the third-party's privacy policy. This policy covers the use of cookies
by PTHippo.com only and does not cover the use of cookies by any advertisers. Cookies are
unique to each computer. Therefore, you must opt out separately on all computers you use. If
you delete all of your cookies, you will have to go through the opt-out process again to reactivate
your opted-out status.
Web Beacons:
Web beacons (also known as clear gifs, pixel tags or web bugs) are tiny graphics with a unique
identifier, similar in function to cookies, and are used to track the online movements of web
users or to access cookies. Unlike cookies which are stored on the user's computer hard drive,
web beacons are embedded invisibly on the web pages (or in email) and are about the size of the
period at the end of this sentence. Web beacons may be used to deliver or communicate with
cookies, to count users who have visited certain pages and to understand usage patterns. We also
may receive an anonymous identification number if you come to our site from an online
advertisement displayed on a third-party Website. Third parties may use anonymous information
about your visits to our site and other Websites in order to improve its products and services and
provide advertisements about goods and services of interest to you.

";
        //" " + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " +
        //"\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" +
        //"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" +
        //"Aenean massa Lorem iconsspsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa." +
        //"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " + "\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" +
        //"Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa." + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " + "\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa." + " " + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " +
        //"\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" +
        //"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n" + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. " +
        //"\n\n" + "Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.\n\n" +
        //"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. \n\n";
    }
}
