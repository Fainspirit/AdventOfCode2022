using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day3 : Day
    {
        public override void Run()
        {
            string[] lines = input.Split("\r\n");
            int totalPriority = 0;

            string[] group = new string[3];
            int memberNum = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                // Part 1
                /*
                string left = line.Substring(0, line.Length / 2);
                string right = line.Substring(line.Length / 2);
                Console.WriteLine(left + " " + right);
                

                // go through left half to find the wrong item
                foreach (char c in left)
                {
                    // this one :D
                    if (right.Contains(c)) {
                        int prio = GetPriority(c);
                        if (prio > 52 || prio < 1)
                        {
                            throw new Exception("Bad return");
                        }
                        totalPriority += prio;
                        Console.WriteLine("{0} : {1}", c, prio);

                        // done iterating this string
                        break;
                    }
                }
                */

                // Part 2
                // Assign member
                group[memberNum] = line;
                if (memberNum == 2) // last of group
                {
                    foreach (char c in group[0])
                    {
                        if (group[1].Contains(c) && group[2].Contains(c))
                        {
                            totalPriority += GetPriority(c);
                            break;
                        }
                    }
                }
                // advance cycle
                memberNum++;
                if (memberNum == 3) memberNum = 0;
            }

            Console.WriteLine("The total priority is {0}", totalPriority);
        }

        int GetPriority(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return (int)c - (int)'a' + 1;
            }
            else // ('A', 'Z')
            {
                return (int)c - (int)'A' + 27;
            }
        }

        string input = "hDsDDttbhsmshNNWMNWGbTNqZq\r\nVQfjnlFvnQFRdZWdVtqMGdWW\r\nzvvvRnFFfjjlRBlBPzgQgRvvmtrmhHcptLHCDhcHHmLsBmsB\r\nFrzFvvdTDcTnmTzdDTTzdvWmjhgVPrhSljSQSPwPjPjPjSVC\r\nsMsGbqGsbbRqRbBMBGRMbLpNSSpjhlQljHVClhjgPjjPhlVp\r\nsNbGtJbMfssNtvcnWFVmnvDd\r\nTNfmdFJmfdZMQffVRQVV\r\njVHBCcDSjWrMZjvg\r\nSShSbCGpcBtBtwtVLJJddmtLmT\r\nCtpNftbNWbtSJDHqGZJFLfLr\r\ndPsHlsRBHcZdqDFDZwwJ\r\nsnjVlvTPlPjVlQlHWjpSmzgNNzSmtpSm\r\nqhZtSVqCqThGcGzZnnfZcB\r\nWbddWbDwrBzcpzHpBb\r\nDBBMFWRJDrDFWLWljCqjQjFvtCsqTjqs\r\nvhFTzRzzTmPvbplWFtQttQQZtZhMZqcqSQ\r\nfJVCfDfJNCLDwJNGmssZgwqgZcmtgcms\r\nVmdVNLHGGVDBdfLCHnLGHnbWpTplWbddRTlzplWPpbFp\r\nsmwtNVqRjNmZjZBDSvzSzl\r\nFnTJFcTTFccCrJGTLncdCCcPJZfBBDSlSJwZDlggSffvgSSf\r\nFWTFGLFWLCPWrCnFnQWNbQVVwphhmHHbptVsss\r\nBrrgrtgfBpPFhhgMWq\r\nZGvsvDGClvsSRScpGBhPphWMPhhTNh\r\nSBSBdBZCcdwHrVQwQr\r\nqmFqdVtqsVdzqGbwMJwGPpmPHM\r\nZjTjLQLLDrrLjcFhlfrGHppfbJwGpMMpGHwRCC\r\nBTlZjrBBBcLTcDrjBlThWBjBtWNqnSzSnsSdvsFggNnqVVnv\r\nzVvmjGgpcJnbTTTJHRHSRb\r\nNPFrFQfCLPrdRlbtQRRvBtHb\r\nfrMLqPFMrfrPLCwqqNvjczwwnmwggGmssnmnnm\r\nHbFJhhshsffcvslmGmLFrQBrlFTG\r\njNRPwwPjSPCdCdvRzRBTlRzmGrmB\r\nnCSWdNjCCPqvtttZnDscth\r\nScSrRTPcSSDRWSptWcdmmWGbmGGLmLJvNJNbbJ\r\nflzHjFpZjFfjjgszjlqzJNnnvsmbMmGvJLNNbmJv\r\njFZFVpffpVlqfQhgtTwcTVtrTcRBwBTD\r\nrHrdGSMSSbZbjShj\r\nqZfDBBvllvvWLtqbbQwhJjbtwbnQgN\r\nWzWlzZmLWBLZLzCzrHMVcRrMRFRCCccF\r\nBzdplppDlBBrqWnjFMBWqNWq\r\nwhZhZSSHhhVSrvSgHPvgvjnFTPsFFnnNTcjTFnTTsc\r\nHLCwVSfZLffSHhLvwtQbJbrdGlRRrGdmpztG\r\ngrDFfDlfCftCzCfNztclNFrBNQjbZjJjjPPVsjNvsbvPsj\r\nHwwTpGpRwMdpHWhvjzVsPJjJGVvVZs\r\nShphRpwzMWdpHdwWHwMpnHwLDmmgcLCCDtLDCCSlcgcfCD\r\nccqqLLqCqTSlZMLQMllZTvnNfjddttmmDpRJjvhfpfthRmdf\r\nrbVssWwggFrGsWzPbVFGJpftQRPDmQDpdPmdJmfR\r\nbBHWWHzWHWWHrsVbsFgwbFqqMLTnBclTMMSnLnqLqMQZ\r\nCcSPGCCPrdPtdjcsBLDghbVLhqDl\r\nvMJwTHzPvzVwqBBDblls\r\nQNvMFfRMJHPZHjnfWmdftSjSnp\r\ndnBCPhhBCrQfChdbNVGLszzDzVDsTbWT\r\nHgcJgpppPqqHwPwJSczVzDssNNVWTtqVVGts\r\nJHRFpjFccplcRwPJpHPScpMPQmCdBQQfQjjhCfBCrQQvdmnn\r\nrQGmVRLRbDRHmmZLGBGVLHBVFspSstWWWNJcsgpQTSsNppJS\r\nqlldhPdfCgnspJFWCFsFNT\r\njMMzwndfhnwPfqPMjgjMVBrGBmrHDHLZbjRGHbHj\r\nwzpZfzHRSRfzgHfffZwwStCtSrBhBBCTrtFhhBFG\r\nQPjQQQDcDWJNFWtrtWrGmTCMtmBW\r\nlDvvDQcdjQcQLvlDwnpFgbbznZZglZsl\r\nRfMFTMFrVrSRFPlFSfVlHpLqgzpHBLzHBBVzVpHG\r\nCchbhcwdmdJmwJJtGgnqzppLmGGBQqQp\r\nhCsstCJwLvMRvsZsTR\r\nfQlfMlNClQhhZhrlWrWw\r\nnjDbnTDTBtGjmrGvSh\r\nbgshBdBcDbTTdnnnTqcqLgqfpfQppCsCMsHHVVpHHNCHFF\r\nPbCnTbzJnqQNzbbTNDdpwcmjDmwjGQjccw\r\nhWgvSdLvwcGjSpSm\r\nvVfrFvvhHFTZndJq\r\nFFvRVCRqVRcfsDLrgqGNWjjHfhQQzGWjQHzN\r\nppJPBwplwSBJTmPpTzWWStzHHjNNLNzHNh\r\nwnwMPbLJMJllJJwBmJmnLVvCvsCsbFgDrRrsCsvrqc\r\njqHgVgdgGQttWCtNqNflmllgFnfDnmFFlpcl\r\nTZZsrrwwhwrsrZRGmhcfSnhGlmSFcf\r\nrsLvvbJPPLBGPCQqHWtMCMHN\r\nWzzBpCBpMsBpCvCfsgnPPfHgbfFNfF\r\njtdTLLjGTGjDjLbbbGlDLLLmfFgmmfgrPrgmNPHSnnNnqFSq\r\njbRRbjlwlRVpvWwvzBpB\r\nqpwzCzCznFznTcCvrcrvVcLb\r\ncPmNMHSlMsLfvWgsrWvL\r\nmMHGPDMBGSGPHlPBcBPzznnzpdQFBjqRFdwdnn\r\nQGZLJzmJrZgZzZhNQFqDWlWPWDFCWNRlPW\r\nhMMbhVbhHWCsPWCMRs\r\nBwjbSHVBVvfcTfZgZzQhrzdGrt\r\ncvPTjfDPpDmmBjbQjZMdlBZj\r\nCHNnghNChVzNgrFVwCMJLMMMMMQQdbLZ\r\nFNSzShrHhNnWgVnWfvfbpfpDGTfvsG\r\nFFpVrZhpTlSQlQzTtRtZHfmPmJDbRtZJ\r\njNnwBLnWwBgNBNCwsNgsMsCLVfDWfmDJRffmRRtmfRmPDRtR\r\nBnLdNdjnBNcLngdCVBndgllFlQrrpQlSSFrQphFcQq\r\nJmVLJPMNjmVJpMLJSVmNQZZQZZrnTHqZQHTrTTMr\r\nltfdwChhwRdRswDDdnBQqqWNTqrrHrqZRr\r\ndwdwwDwsGlhhDFtsCwhsJLcPmGPcGzSjSjjLzNPS\r\nQgSbgQCLQSJFMccLFLVVzH\r\nWBNffrBpBNdNRdWDfptBtdzWcMZZVPMVwHMmsVHFccHsDsVc\r\nptphRWrfGRGRnqlCSQvhqbCzJS\r\nVvdMLMLMBMlVlVschsNpDGpdNsGc\r\ntqFSmnmnnttGfDqNcfvNDD\r\nnzRHnrwrrWRrrzHtbMlTMBjCvWLgBBMl\r\npCBlRvzwzlCzvZqqDwzmvgtsLsQdgZsgPNtdrsWrst\r\nJbGjbGVGHSFbhbnhTShSTbQtQrPsLsHLQgNRtsgdQsLP\r\nGnnbJbGMGbSjjbSbCzqlwMRRDzqzMBBv\r\nTTVRJVMWMshSQtjSVTQJRQlcCBncJccdppnJcBBDngFpgP\r\nfrvfzfHrwzZNrtNwzzzZncCCZFdFFCgBDpPcBcBg\r\nLwNGbqwvmvvtbNQjQlVVRWTGTQWM\r\nRnggwVLRLDfCVZhfpDGGMGMGcGzGNHvv\r\njmmWBTSsBmFmSzctsqpccHvzpN\r\nSBSrTblSQPbQhNwwZfPVdZPf\r\nCCvCwzfNStLzfrbmMJbZMtlsbJMW\r\ngPPPBqDjBcPFpVgBRbnMsVsbJZnWsdbSbM\r\nqgDPHjHcPhpDRRpPBRpCGSLwvHQwGfzrHLGLTL\r\nCLGqDZZLTdddPsdJpq\r\ngbRbbnghnrWvgrdJdSTRSsVNJlld\r\nhMnwrjnnjggvnLDwGffTfwCZZZ\r\nNzJHbNHNNzJzgmHmzpQSvvLqbLsVVsVGvB\r\nWtWhtWDdrZldDWrWTlZgppVVsqQTVQBqsGqBsQVp\r\njWjWRRRlPcHRwJgw\r\nCCnnFTmnPCMCRNfnwGwdfzvwwl\r\nVQQVShDSSshhDDtDLhjccGjLBBzBzlZflNZvwZzdwBzpSNNZ\r\nQLHhJDDhDhgscgtjbGHTrWbrTbRmbFrm\r\nCJbLvJvbwtFHqvLzwJqqqtHWTWRgDScDRSWQQjTRcWRDLT\r\nmssGsMNphZMNsPPBnhSjRgdnQRdWgdjgrcDn\r\nGGmBMMsffmslMGshZlMphGqCzHCbzlbvzqwzzgFJggCF\r\nWCgWBphpWLQZQpgdhGdwmfbfFRVRjRTbbSFttdbSbT\r\nqqrZnDNqZJDTVzRjVFbfSN\r\nrPMvqJJqrJMPJnZMZZgLPgLWLggWQghwhmBh\r\nCWGGzdHHmPPSmPsC\r\nLqwlZwRLrPMQlMqrlbZrQRsSNsmssSNSsNcBNpgmsJ\r\nlwLDQhrDMQqPGfhzGGjhGn\r\nZqDlZssCqJJMvpdBpBBmBQSMRp\r\nwLgVcbgFLzTLTNNZmNNRdjdRmF\r\nHZHbctWTwgVWgsfrnnPqlnsWlD\r\nRSnwSPFcLnFPnRwjzctzbGNlZgNbbGdGpLhZdpgM\r\nBqqBfMvTmmJqDgGNVdGVbVJJZG\r\nvsTDfqBmHmMWQCwjtrHjjSFFnRSn\r\nLsCmmcDHRjdtNMstwwzJ\r\nTvThqfBFBNTnnndTtL\r\nlvGQfbFQGblFrRccLRSSlPPVHS\r\nqbLpqTHSqpbqbrPcQgjPDjcdDL\r\ngnzhhBBwBWZzMglmjDrDPjvfdvQPdwtd\r\nWZZzZZlZmhsMmFgRBBBzHHJpNJGVRSJVGTVpNqCH\r\nJDphhGhDdGzWRBnvqqLDNLMnLw\r\ngsrTHHffTHPcrPrlHCNZhvBZnZNLhPvBNwvh\r\nsHVCSsSghJpSJjQh\r\nJTMGlfjlTdqjnqbnqFwqmnbQ\r\nPBZhBBcWRZprPZcZDDCZTZRgnnzwbbsbnvhbvznFsNFFvvNQ\r\nBcWrVgCCZTDRDrlGttfVtMddSJlH\r\nvwwvpVbSvnSRRmfMCmTHVHTBHB\r\nQLZgDPgSDgGTMZfmTTBZ\r\nQDDsQFDlzlgtJlLdFDgSJQFvvpRvjqzjRwwwzWvhvWwqjj\r\nmRRTGGNNflGRGGmmgRblsGwCZwVZlZjVwjztpjZhpBCB\r\nPMLLFLHPLPnLqDDLvFDrzzMjhwVCjtphBzjMhV\r\nFDdSPSpLcDsNRRWSTNWN\r\nSTldJthdJbtTqljCRDDHmqmj\r\nVVvNwwvNFssJFJPNNwVvRMCgCgDqjjjqrDqqMHqP\r\nQBZwQfZwfVhtcSBtBJnT\r\nTzjjPzsQTslNlNzPRVGJJJGGtTJmgJHtmTZC\r\ndBDWScMBhhPGgdwwJPfw\r\nSqSqbSPDBhqnMqvrrSWVNFpRVRLzVQslvpNjVL\r\nbWFgFCPFtgvDZWgtChDNFJHvGVzHHpjzHnnzGzzHRR\r\nqcScQbbmqdQmlQmrlcQwLmHlRRjzGHnHJnnGVjHzBHzG\r\nTqQwmLmfcddfwrfCgbWCNPsZNfCb\r\npddprrtrCPdvJdMjwwwHnLwwjLWCLg\r\nqhzZTmZcmRhmpFlVHcQQVwWQHVQwnH\r\nlGmhfRfmBZRlmmbvDPBMvNbvJJpP\r\nNsptgfGLLNwnNQSZbCvZnRnMCb\r\nJldhdzwzBMCSZvrz\r\nJFcdWTdwhPTFVDVmTJNqmstLqgLtLtjGGpsG\r\ndVVTSgTDpHVDjgdWpdpHTZSbWGrnnvrNwzFGNrFwnNNwvh\r\nCPRlMPJcMQcBcsmmLCMPrzbFfhwfrvLrNNwwGwfF\r\nCRJmtbmJlQbsQlRBpZDVjTHTdjDtSjZt\r\nrQVJrRFdrwDfzHQHQBTnpWTW\r\nPCLbPcPCsgqCgPgLjScSqNbHTzMtWmWtzlTHmBtTlMssMT\r\ncCqghSSPcvgScPbwFGdDDVZFfDhZGB\r\nzrRQRdqzPHQtnMPrtzPMRRQMVBBblJJBSClBpJbpdCCbBlCC\r\nhTcGwzswGwGmGfDvvfGmGNfBpllVSWbWppNCBNBVpCBClW\r\ngvGFTmTgwDhTDccsTfzfmfGGQPgPPqrgRZPHnRqRZrQLnRgP\r\nhvmmJllPbmCRMNGMMlNwNl\r\nPFTpTVjTgpTpBRgMGMnRNHBB\r\nWWrqzTTPVQDPqpjTqPJbmLtcfsQsftbLbvct\r\nSzrmpjjcsjTZNzgnnNzN\r\nBLHNDwBLBPLwLBhwDVLgdQCgCQGTngHQZCngZd\r\nPPJBDvBVVBmppNjJjrrr\r\nZHBNQFhsqHBsgCfqtctcPvSwPqrV\r\nLlnGTnJpJJTmdDpmLlmLndWfVrPvvRwDfcwwwRVwcfQtvP\r\nGnbQblWmWGdTJQdTGnZHsHhZhFNsbCsjFgjC\r\nhWfDzDTVndDMhddMlBWMBDfJRnRtvvSSQjCvZCtjtpJvSR\r\nbGHsccFcbscsqGPHNGcrpjJZtvSRtFtQCZrjSj\r\nGsbwGGwNNGLgPLwMzBzfMMVMTLdTCC\r\nGBcNzTSSmGzmTLNgvwgpNCDqpDggpw\r\nJRZMrJWFZZnZtJgvvjwbpbCJDd\r\nrFMPRhZtZFnWrRtQGmPPDcLfmGLTfz\r\nVdWnVdjhhdFjVWbndMlNLQspVMHCNVlClV\r\nRSrJBRRJwJSBQpMBHLLDCL\r\nTqwtRRRJzJTSqJSzSrtmqgWWhcncvPgnWbPQnbnWmb\r\nVnDFpPpFssVSpFDVHbRbscCvgbMTvTCR\r\nJfzqdQBfhBdddfBBGDLdGQvbrqMMcCRRMTgbqgMrbbqc\r\nQDfzJNWBJLQBhmdGDzDGhQGGlFZwPtWjtFFppllSVpZZFnjj\r\nqrLLNpJbJnRLNnpvQtRVhhRFCdlFFlFd\r\nmmjzjvGjwPwmTsSTSQjDVlVWQjlCDthCCC\r\ncSSmcTTPcSswScfSHmTSTzJqqNrnpBpqBbJLvZMrqfrL\r\nNSvRZRfFvfHSZQcNJBLbzDLnrDFnhtFLFnrh\r\nwmTGpmGCwsMplMsHllPlMnDLjznrgrzDjgnntznr\r\ndsCVGGGwmpTGPplmCmPppVmHSSRJNfJvBNZQfWdBRJZRBZcR\r\nTwQwqDPQtwNwzNDTZcnZbJvMnMMbFqZM\r\nSzGSjrjLWrjHHspWVhvVVnFJbccVZcRJbllb\r\npHppszGSprhhWHLCLrsjdTtDDPfwdfwtdNfDgNCN\r\nftcvBtBFtmBlmvPFmmcczCChrgSCzzCSnCSSnGHf\r\nsJddbdTDbDHdnJRggrGzGzrG\r\ndppDVDZMMMsTTVsDTsTDpwVctNcvBZQPcPctqtQcHmvlvQ\r\njzbdzztbDqNqwvLvRmQZjvRH\r\nFSJbFFWgJnZFLRZmHmRQ\r\nTgVJTVSJGJcJlllgTMdqpdNsrztNNsNbMDDp\r\nCCCVWbwVnlRbTcqSShqGhhGcnF\r\nPgDBfDpMNlfgpPfNZZtcJgcqqhmmjqSmjFmhmS\r\ntpfpsPrlpsPDDMDfBZrwLrVWLLLWRCdHLTwbVR\r\npjvfDGjSMpvDmDpDpSDnJmfqbPVsCMFsPqFVPqCrwrbMFV\r\nNQlHtHNhZHgZZNBHhQgzPmCwbqqVFlsrPFrFCP\r\nhgHtQdQchcHctHgcgNgBQdWNpmvTWvpGmLJDLGjTpLGnnjfv\r\nQhgLLLmtlRqDtRGP\r\nHLbnCZFWVHLZnFCJJRFrGJzDGDGJDD\r\nWZHfndfMfCZbMnTVTfZhSNQQpdwSdLwhNcmdSN\r\nsPwrPMgLFPFFsLZtmcclSSZDtcZs\r\nqVzqdNdCnnNVVNCGmbncDBlmBlBBnRlZ\r\nVTdCGVvVfffrjpfMQPwm\r\nBPDldDTDPZcggjcccTdNMbbMNSQNqqjtzMbrRb\r\nLvmWsfvssLGnQbQMRQqrSRnz\r\nWpvsVmmpmmfpfJGrHfVCHVvmcDgpDlZphgFgdhclhdgdBlgF\r\nVGwHbNzMMrzHbbHChhqgCqPNghgCqW\r\nZJVBvBvZWqvRvggP\r\nJBJlBlBZcsBfcJVrHnLwQQGzLQMc\r\ngBWfBPPPfhvVWFfSVfVdjjbvTvwwQppHcHcctTcQTHcZ\r\nDnNnMJMqMJzqchbZtTQQrb\r\nllRmNLDLDGlCsWSFCffWdshd\r\nLpNMZZpqqpfTTwNqLZwGsZqZbdHRHbHGddnCBHRcmzGmmCdG\r\nJFRtRlVStjPlhtjbBzBncmVWdzWBnb\r\nrPhhSlrvQlFFFPgtJlJtFlhlDNTwRMfZTZfDZNrspZLMMsrq\r\nzBLjLFBjLjmHWlzNZlzVCC\r\ndcJrdfddbllJbdMTwDNMZWNVwVDwHT\r\ngRcgJbcbqfgbftdjlqLhFFLPPhGBjm\r\nWfBgBRzQGNNQqmmqZN\r\nnFjCjCpLbtpPJtCDDnCDJpzncrSVbmdVqbhhdqNbSSmrdVSq\r\nCLPJpDLlLlFDpFjjsGRsBGRfWwsHHglz\r\nlSlSlpCRSsWTRLTlWRvlmMrBPjBPjpqrrmqPJMPZ\r\nDDzbhVhQhDGzhQnGGfnHHQGBPZjMqJjBJMBVJmqMdrqqdT\r\nNNGQbFwnHzNzwbQwFnwbfsLCLtsvLsWggFslsTggSc\r\nnvzPvCnlvtwCrZWmWwvvZCQfbbfQfGbqSJJGmqGSFSbJ\r\nLhTBWdsMNNRgNcgDWsDNcVSfQqJGFSFJqSSddQGSJF\r\nHNgchHcWDRNhTNMWwtPrtZZjnHzrnvCz\r\ndjhnzRghMMVCBfhh\r\nqjQTrTPQJCDDqBDJ\r\nLQvGrLjTHLjNNPPTpQgtztSmmbFgmgLbFnmL\r\nFRDNFBBRRVFFmbLZHPZBZvvH\r\nQnhgMllglJTdGgJnhLQQJpZpvwZHpwsPTwpbsZHmsH\r\nlnhnQGrMgthMlntlGfQhgWWcRSDcVCrLWzRSrRFDRN\r\nPqrrrRnPBbrVhVqFrFVRPVhZLvNSNvLZcQvtJfRvNScJNJ\r\ndDzWwwCTmmdwdddpDLWQZMSSMfSJtcWJfQSQZN\r\nCCwmTdjsClVjFjnLBl\r\nsrjCvjPmQVlPjFPmQmPrdHHZhvHZDqHhDDwHHqfB\r\npLcnJQNQMZpqZDDZ\r\nWNRbtNJgRPjjQVmz\r\nNJJRmjmJbbJfqSVMNHFCSFzLLlrLLrFHTz\r\nQvnsQGvBwWwQvgRHlGGDFPFCGlrR\r\nQhvwBvBctBccZWZNRNmVfjpmjJjb\r\nRMmGGMLRRCFmRPPfGFpGPFPJWZQWctrtlQvZvltfrQWcWWBq\r\ngggwjjbjwwbZtwZBBcmQQv\r\nSdNbDDVSgPMFmPzdMm\r\nnZhnNZDnZPmZPWbppPpMlvRlzvrtMmRtqRzRfq\r\nHcFwsCQLVQwFwLtLbvtzrlrLtt\r\nGsgCFCgCQHHCVHsFQHcFdDPDbJDZTpZDbWJPNWWZDd\r\nBBrBrGlGpgGjsNhlBlpBwpfSwZJdQwfcZwvSQnnn\r\nLvWvHLmmVJQQHfQH\r\nRPLRMvqFTbRTjGBhjNFsslls\r\ncNZZZmZDcDDJmhzzrrlHtSbvgjSvgfPSWvPfjShv\r\nVBwnndnVCqbqpRRpnspnqRWtGgWSSgvFBSGGSWgtGGSP\r\nLqCMnTLVRwCRCpRLpbHDNzMMNcmmHNHQJQ\r\nMMqDtnVnBlHtZvtB\r\nWLWrWgdWwdrLCTFCwLlbbsJsJQsbQlQzlvrB\r\njFSvTdjfnfRmVcRR\r\nZLGqnvnqLzvbGRMfcRpwMpdV\r\nfgfNNfgHHjVmRcVdgM\r\nHsWDCDfCQCZBBZnvWtLq\r\nbTZjqflqZhcrlczGzppGNgjmFNnp\r\nPmmRSWWDMBQVNpWFznGF\r\nSStRBDSCCSSSwPBwBDBwPmZhZlfZhqHTsTfltHHZfsHH\r\nGbNbsSptQGqsdJCzsddcgzzv\r\nDHRRnmWWmZnmRhllnHnnnMLvvLgcTVvjVhCTvgzcJgLj\r\nRnWMlDZRlnHlmHWBFwGQqNGGPNQzPGqFwz\r\nvSGvHpJnBLbGHBNCgfDzzChDgbCfzT\r\nwFRslqmqTRgggQghPmQf\r\nqjRFMjWqNNMMGHTL\r\nfWGcQGGSRFQZhttZJfSSJflDDrwdClljVrNDdrdCFBCr\r\nMTgvLLPPnHzMbDwdlNbMBwMM\r\nmnTvnnPTcNmmJJWN\r\nqqbbQQnbWrqGgnWqvZpVzMCZjCgfjZCSVM\r\nldcmDPDhmlFBHPDddLBVFDHLppZpjSCjjNfwNMwCpSMwhCMp\r\nFtDdsHPcHmdHVPLtHsdtBHQnsbvnTRRTRsRRqbqvqWnJ\r\nhhtBtPrgbbhhgjZjjCCHHNpNDHpffHWCvr\r\nLGFLVwswsJMSgFwMMpddSvpHCCdDdvCpvm\r\nsGsFsQLsVsLFnnFTJQthjcjQqhRcBZZtRg\r\n";
    }
}
