<?php
	 class C_tpd_report extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPD_REPORT.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPD_REPORT.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpd_reportid' =>  $this->input->get_post('tpd_reportid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
            $tpd_report = $this->m_tpd_report->setRow($data);
            print json_encode($tpd_report);
    }
    function newRow() {
            log_message('debug', 'TPD_REPORT.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpd_reportid' =>  $this->input->get_post('tpd_reportid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpd_report= $this->m_tpd_report->newRow($instanceid,$data);
            $return = $tpd_report;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPD_REPORT.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpd_report = $this->m_tpd_report->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpd_report
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpd_report= $this->m_tpd_report->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpd_report= $this->m_tpd_report->getRows($sort);
                }
            }else{
              $tpd_report= $this->m_tpd_report->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpd_report
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPD_REPORT.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpd_report= $this->m_tpd_report->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpd_report
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPD_REPORT.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpd_report= $this->m_tpd_report->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpd_report
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPD_REPORT.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpd_reportid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpd_report->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpd_report', 'm_tpd_report');
    }
}
?>